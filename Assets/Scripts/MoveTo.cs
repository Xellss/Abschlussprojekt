/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class MoveTo : MonoBehaviour {

    [SerializeField]
    private Transform goal;
    NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    void Update()
    {
        agent.SetDestination(goal.position);
    }
}
