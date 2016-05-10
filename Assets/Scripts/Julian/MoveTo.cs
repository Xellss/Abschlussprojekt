/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;

    private void Start()
    {
        goal = GameObject.Find("Goal").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(goal.position);
    }
}
