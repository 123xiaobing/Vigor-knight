using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public static BulletsPool bulletsPoolInstance;      
    public GameObject bulletObj;                        //子弹perfabs
    public int pooledAmount = 5;                        //子弹池初始大小


    public List<GameObject> pooledObjects;             //子弹池链表
    void Awake()
    {
        bulletsPoolInstance = this;                     //把本对象作为实例。

    }

    void Start()
    {
        pooledObjects = new List<GameObject>();         //初始化链表
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObj);    
            obj.SetActive(false);                      
            pooledObjects.Add(obj);
        }
       
    }

    public GameObject GetPooledObject()                 //获取对象池中可以使用的子弹。
    {
        if (pooledObjects.Count > 0)
        {
            GameObject bullet = pooledObjects[0];
            pooledObjects.Remove(bullet);
            bullet.SetActive(true);
            return bullet;            
        }

        else
        {
            GameObject obj = Instantiate(bulletObj);
          
            return obj;
        }
        
      
    }

    public void Recycle(GameObject gameObject)//回收子弹
    {
        gameObject.SetActive(false);
        pooledObjects.Add(gameObject);
    }


}
