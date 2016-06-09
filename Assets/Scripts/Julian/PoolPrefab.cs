// Copyright (c) 2016 Daniel Bortfeld
/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Changes by: Julian Hopp         ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class PoolPrefab : MonoBehaviour
{
    [SerializeField]
    private PoolPrefab prefab;

    public PoolPrefab Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
    private void Start()
    {
        if (prefab == null)
        {
            prefab = this;
        }
    }

    private void OnDisable()
    {
        ObjectPool.Instance.ReturnObjectToPool(this);
    }
}
