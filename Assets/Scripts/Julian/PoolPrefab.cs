using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PoolPrefab : MonoBehaviour
{
    public PoolPrefab Prefab { get; set; }

    private void OnDisable()
    {
        ObjectPool.Instance.ReturnObjectToPool(this);
    }
}
