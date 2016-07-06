using UnityEngine;
using System.Collections;
using System;

public class LookAtEnemy : MonoBehaviour
{

    [SerializeField]
    float lookAtEnemyRadius = 0;


    void Start()
    {
        StartCoroutine("lookUpdate");
    }
    IEnumerator lookUpdate()
    {
        while (true)
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

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, lookAtEnemyRadius);
    }
}
