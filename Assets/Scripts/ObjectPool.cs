using UnityEngine;
using System.Collections.Generic;
using System;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
                if (instance == null)
                    Debug.LogError("You need to have at least one ObjectPool component in your hierarchy");
            }

            return instance;
        }
    }

    [SerializeField]
    private List<PoolElement> pooledElements;

    // Dict<Asset, Queue<Instance>>
    private Dictionary<PoolPrefab, Queue<PoolPrefab>> poolDict = new Dictionary<PoolPrefab, Queue<PoolPrefab>>();
    private Dictionary<PoolPrefab, bool> canGrowDict = new Dictionary<PoolPrefab, bool>();

    private Transform myTransform;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    void Start()
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

    /// <summary>
    /// <para>Returns an active Instance of the original Prefab-Asset from the Pool.</para>
    /// <para>Don't forget to reset the returned Object.</para>
    /// <para>PoolPrefabs return to the pool on SetActive(false).</para>
    /// </summary>
    /// <param name="prefab">The original Prefab-Asset.</param>
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

    /// <summary>
    /// <para>Creates a new instance of a prefab and sets it inactive.</para>
    /// </summary>
    /// <param name="prefab">The original Prefab-Asset.</param>
    /// <param name="force">if true: force the pool to instanciate a new object.</param>
    private void EnsureNewObject(PoolPrefab prefab, bool force = false)
    {
        Queue<PoolPrefab> pool = this.poolDict[prefab];

        // if (force == true)...........................................................then instanciate a new object
        // if (force == false AND there are no objects in the pool AND it can grow).....then instanciate a new object
        // if (      "        AND                "                 AND it can't grow)...then no object is instanciated
        // if (      "        AND there is at least one object in the pool).............then no object is instanciated
        if (!force && (pool.Count > 0 || !canGrowDict[prefab]))
            return;

        PoolPrefab instance = Instantiate(prefab);
        instance.Prefab = prefab;
        instance.gameObject.SetActive(false);
        instance.transform.SetParent(myTransform, false);
    }

    [Serializable]
    public class PoolElement
    {
        public PoolPrefab Prefab = null;
        public int PooledAmount = 1;
        public bool CanGrow = false;
    }
}