using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public static BulletsPool bulletsPoolInstance;      
    public GameObject bulletObj;                        //�ӵ�perfabs
    public int pooledAmount = 5;                        //�ӵ��س�ʼ��С


    public List<GameObject> pooledObjects;             //�ӵ�������
    void Awake()
    {
        bulletsPoolInstance = this;                     //�ѱ�������Ϊʵ����

    }

    void Start()
    {
        pooledObjects = new List<GameObject>();         //��ʼ������
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObj);    
            obj.SetActive(false);                      
            pooledObjects.Add(obj);
        }
       
    }

    public GameObject GetPooledObject()                 //��ȡ������п���ʹ�õ��ӵ���
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

    public void Recycle(GameObject gameObject)//�����ӵ�
    {
        gameObject.SetActive(false);
        pooledObjects.Add(gameObject);
    }


}
