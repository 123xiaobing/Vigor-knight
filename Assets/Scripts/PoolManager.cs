using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilePools;

    void Start()
    {
        Initialize(playerProjectilePools);
    }

    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            Transform poolParent= new GameObject("Pool:" + pool.Prefab.name).transform;

            poolParent.parent = transform;

            pool.Initialize(poolParent);
        }
    }
}
