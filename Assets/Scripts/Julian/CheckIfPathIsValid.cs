/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Changes by: Julian Hopp         ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////


using UnityEngine;
using System.Collections;

public class CheckIfPathIsValid : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform goal;

    public NavMeshPathStatus PathStatus;

    private void Start()
    {
        goal = GameObject.Find("Goal").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(goal.position);

        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {

            Debug.Log("PathInvalid");
        }
    }
}
