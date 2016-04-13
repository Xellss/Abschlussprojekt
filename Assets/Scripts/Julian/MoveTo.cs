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
    private Transform goal;
    private NavMeshAgent agent;

    void Start()
    {
        goal = GameObject.Find("Goal").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(goal.position);
    }
}
