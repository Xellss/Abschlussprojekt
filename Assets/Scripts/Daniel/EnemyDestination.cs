/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    private MoveTo moveTo;
    private ObjectPool objectPool;
    private GameObject objectPoolGO;

    private void Awake()
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

    private void Start()
    {
        moveTo.MainBaseLevel = objectPool.MainBaseScene;
        moveTo.SearchNewBuilding = true;
    }

}
