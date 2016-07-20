/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    private bool lookActive = true;
    [SerializeField]
    private float lookAtEnemyRadius = 0;

    public bool LookActive
    {
        get { return lookActive; }
        set { lookActive = value; }
    }

    public void EndLookAt()
    {
        StopCoroutine("lookUpdate");
    }

    public void StartLookAt()
    {
        StartCoroutine("lookUpdate");
    }

    private IEnumerator lookUpdate()
    {
        while (lookActive)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, lookAtEnemyRadius, LayerMask.GetMask("Enemy"), QueryTriggerInteraction.Collide);
            if (collider.Length > 0)
            {
                var direction = collider[0].transform.position - transform.position;
                direction.y = 0;
                transform.rotation = Quaternion.LookRotation(direction);
                //transform.LookAt(collider[0].gameObject.transform);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void Start()
    {
        StartLookAt();
    }
}
