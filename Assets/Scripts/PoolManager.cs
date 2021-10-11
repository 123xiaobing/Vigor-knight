using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilePools;

    private void Start()
    {
        Initialize(playerProjectilePools);
    }

    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            pool.Initialize();
        }
    }
}
