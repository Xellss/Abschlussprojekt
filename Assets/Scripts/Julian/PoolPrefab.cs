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
using System.Linq;
using System.Text;
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

    private void OnDisable()
    {
        ObjectPool.Instance.ReturnObjectToPool(this);
    }
}
