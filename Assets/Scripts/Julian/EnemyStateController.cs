using System;
using System.Collections;
using UnityEngine;

public enum EnemyStates
{
    Idle,
    WalkToTarget,
    RunToTarget,
    Attack,
    Dying
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Weapon))]
public class EnemyStateController : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float viewRange;

    [SerializeField]
    private float attackRange;

    [SerializeField]
    private Weapon weapon;

    private float attackDelay = 120;

    [SerializeField]
    private Collider mainTarget;

    private Collider currentTargetCollider;

    [SerializeField]
    private string[] hostileTags;

    [SerializeField]
    private bool IsLookingForHostiles = false;

    private Health targetHealth;

    [SerializeField]
    private EnemyStates startingState = EnemyStates.Idle;

    private EnemyStates previousState = EnemyStates.Idle;
    private EnemyStates currentState = EnemyStates.Idle;

    private Transform myTransform;

    public Collider MainTarget { set { mainTarget = value; } }

    #region Unity Methods

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        ChangeState(startingState);
    }

    void Update()
    {
        if (IsLookingForHostiles)
        {
            CheckViewRange();
        }

        ProcessCurrentState();
    }

    #endregion Unity Methods

    public void ChangeState(EnemyStates newState)
    {
        // agent is already in this state
        if (newState == currentState)
            return;

        // transition is not allowed
        if (!CheckForValidStatePair(newState))
            return;

        switch (newState)
        {
            case EnemyStates.Idle:
            case EnemyStates.WalkToTarget:
            case EnemyStates.RunToTarget:
                StopAllCoroutines();
                break;
            case EnemyStates.Attack:
                targetHealth = currentTargetCollider.GetComponent<Health>();
                StartCoroutine(Attack());
                agent.Stop();
                Debug.Log(name + " starts attacking " + currentTargetCollider.name);
                break;
            default:
                break;
        }

        previousState = currentState;
        currentState = newState;
    }

    private void ProcessCurrentState()
    {
        if (currentTargetCollider == null)
        {
            if (mainTarget != null)
            {
                currentTargetCollider = mainTarget;
                ChangeState(EnemyStates.WalkToTarget);
            }
            else
            {
                ChangeState(EnemyStates.Idle);
            }
        }

        Vector3 targetPosition = currentTargetCollider.ClosestPointOnBounds(myTransform.position);
        float distanceToTarget = Vector3.Distance(myTransform.position, targetPosition);

        switch (currentState)
        {
            case EnemyStates.Idle:
                break;
            case EnemyStates.WalkToTarget:
                if (distanceToTarget <= viewRange)
                {
                    ChangeState(EnemyStates.RunToTarget);
                }
                else
                {
                    WalkToTarget(targetPosition);
                }
                break;
            case EnemyStates.RunToTarget:
                if (distanceToTarget <= attackRange)
                {
                    ChangeState(EnemyStates.Attack);
                }
                else if (distanceToTarget > viewRange)
                {
                    currentTargetCollider = null;
                }
                else
                {
                    RunToTarget(targetPosition);
                }
                break;
            case EnemyStates.Attack:
                if (distanceToTarget > attackRange)
                {
                    ChangeState(EnemyStates.RunToTarget);
                }
                break;
            case EnemyStates.Dying:
                
                break;
            default:
                break;
        }
    }

    private void CheckViewRange()
    {
        Collider[] possibleTargets = Physics.OverlapSphere(myTransform.position, viewRange, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        if (possibleTargets == null)
            return;

        currentTargetCollider = GetClosestTarget(possibleTargets);
    }

    private Collider GetClosestTarget(Collider[] possibleTargets)
    {
        Collider closestTarget = currentTargetCollider;
        float shortestDistance = viewRange;

        for (int i = 0; i < possibleTargets.Length; i++)
        {
            bool tagIsContained = CheckHostileTags(possibleTargets[i]);

            if (tagIsContained)
            {
                float distance = Vector3.Distance(myTransform.position, possibleTargets[i].ClosestPointOnBounds(myTransform.position));

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestTarget = possibleTargets[i];
                }
            }
        }

        return closestTarget;
    }

    private bool CheckHostileTags(Collider possibleTarget)
    {
        bool returnValue = false;

        for (int i = 0; i < hostileTags.Length; i++)
        {
            if (possibleTarget.CompareTag(hostileTags[i]))
            {
                returnValue = true;
            }
        }

        return returnValue;
    }

    /// <summary>
    /// If true, transition is allowed.
    /// </summary>
    private bool CheckForValidStatePair(EnemyStates newState)
    {
        // for testing always true
        return true;

        switch (currentState)
        {
            case EnemyStates.Idle:
                break;
            case EnemyStates.WalkToTarget:
                break;
            case EnemyStates.RunToTarget:
                break;
            case EnemyStates.Attack:
                break;
            default:
                break;
        }
        return false;
    }

    private void RunToTarget(Vector3 targetPosition)
    {
        agent.speed = runSpeed;
        SetTarget(targetPosition);
    }

    private void WalkToTarget(Vector3 targetPosition)
    {
        agent.speed = walkSpeed;
        SetTarget(targetPosition);
    }

    private void SetTarget(Vector3 target)
    {
        if (agent.destination != target)
            agent.SetDestination(target);
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackDelay / weapon.AttackSpeed);
        Debug.Log(name + " attacks " + currentTargetCollider.name);
        targetHealth.Decrease(weapon.DamagePoints);
        StartCoroutine(Attack());
    }
}
