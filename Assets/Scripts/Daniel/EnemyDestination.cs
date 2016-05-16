using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDestination : MonoBehaviour {


    MoveTo moveTo;
    ObjectPool objectPool;
    GameObject objectPoolGO;
    void Awake()
    {
        if (GameObject.Find("ObjectPool") != null)
        {
        objectPoolGO = GameObject.Find("ObjectPool");
        }
        else
        {
            objectPoolGO = GameObject.Find("GlobalScripts");
        }
        objectPool = objectPoolGO.GetComponent<ObjectPool>();
        moveTo = GetComponent<MoveTo>();
    }

    void Start()
    {
        moveTo.MainBaseLevel = objectPool.MainBaseScene;
        moveTo.SearchNewBuilding = true;
    }
    //private MoveTo[] enemyMoveTos;
}
