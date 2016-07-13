/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class AsteroidEnemyKI : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private NavMeshAgent myAgent;
    private GameObject sun;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        sun = GameObject.Find("Sun");
    }

    private void Start()
    {
        myAgent.SetDestination(sun.transform.position);
    }
}
