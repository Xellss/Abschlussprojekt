using UnityEngine;
using System.Collections;

public class AsteroidEnemyKI : MonoBehaviour {

    GameObject sun;
    NavMeshAgent myAgent;

    [SerializeField]
    private int damage;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        sun = GameObject.Find("Sun");
    }
    void Start()
    {
        myAgent.SetDestination(sun.transform.position);
    }

}
