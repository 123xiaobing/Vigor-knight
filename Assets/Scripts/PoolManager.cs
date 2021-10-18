using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Pool[] playerProjectilePools;

    static Dictionary<GameObject, Pool> dictionary;

    void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();

        Initialize(playerProjectilePools);
    }

    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
#if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("������г�������ͬ��Ԥ����" + pool.Prefab.name);
                continue;
            }

#endif
            dictionary.Add(pool.bulletPrefab, pool);

            Transform poolParent= new GameObject("Pool:" + pool.Prefab.name).transform;

            poolParent.parent = transform;

            pool.Initialize(poolParent);
        }
    }

    
    public static GameObject Release(GameObject prefab)
    {
        if(!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("�Ҳ�������Ԥ����" + prefab.name);
            return null;
        }
        return dictionary[prefab].PreparedObject();
    }
    public static GameObject Release(GameObject prefab,Vector3 position)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("�Ҳ�������Ԥ����" + prefab.name);
            return null;
        }
        return dictionary[prefab].PreparedObject(position);
    }
    public static GameObject Release(GameObject prefab,Vector3 position,Quaternion rotation)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("�Ҳ�������Ԥ����" + prefab.name);
            return null;
        }
        return dictionary[prefab].PreparedObject(position,rotation);
    }
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation,Vector3 localScal)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("�Ҳ�������Ԥ����" + prefab.name);
            return null;
        }
        return dictionary[prefab].PreparedObject(position,rotation,localScal);
    }
}
