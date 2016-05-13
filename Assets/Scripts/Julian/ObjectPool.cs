/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    private Dictionary<PoolPrefab, bool> canGrowDict = new Dictionary<PoolPrefab, bool>();

    private Transform myTransform;

    private Dictionary<PoolPrefab, Queue<PoolPrefab>> poolDict = new Dictionary<PoolPrefab, Queue<PoolPrefab>>();

    [SerializeField]
    private List<PoolElement> pooledElements;

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
                if (instance == null)
                    Debug.LogError("No ObjectPool component in your hierarchy found.");
            }

            return instance;
        }
    }

    public GameObject GetPooledObject(PoolPrefab prefab)
    {
        EnsureNewObject(prefab);

        Queue<PoolPrefab> pool = this.poolDict[prefab];

        if (pool.Count == 0)
            return null;

        GameObject instance = pool.Dequeue().gameObject;
        instance.SetActive(true);

        return instance;
    }

    public void ReturnObjectToPool(PoolPrefab instance)
    {
        poolDict[instance.Prefab].Enqueue(instance);
    }

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void EnsureNewObject(PoolPrefab prefab, bool force = false)
    {
        Queue<PoolPrefab> pool = this.poolDict[prefab];

        if (!force && (pool.Count > 0 || !canGrowDict[prefab]))
            return;

        PoolPrefab instance = Instantiate(prefab);
        instance.Prefab = prefab;
        instance.gameObject.SetActive(false);
        instance.transform.SetParent(myTransform, false);
    }

    private void Start()
    {
        foreach (var element in pooledElements)
        {
            poolDict[element.Prefab] = new Queue<PoolPrefab>();
            canGrowDict[element.Prefab] = element.CanGrow;

            for (int i = 0; i < element.PooledAmount; i++)
            {
                EnsureNewObject(element.Prefab, true);
            }
        }
    }

    [Serializable]
    public class PoolElement
    {
        public bool CanGrow = false;
        public int PooledAmount = 1;
        public PoolPrefab Prefab = null;
    }
}
