using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject[] Weapons;//�����б�
    public GameObject[] Bullets;//�ӵ��б�


    void Start()
    {
        Weapons[0].SetActive(true);
        Weapons[1].SetActive(false);
        Weapons[2].SetActive(false);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))//�����ż����л����������ͼ����ӵ�
        {
            ChangeToOne();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToTwo();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToThree();
        }

    }

    void ChangeToOne()
    {
        Weapons[0].SetActive(true);
        Weapons[1].SetActive(false);
        Weapons[2].SetActive(false);
    }

    void ChangeToTwo()
    {
        Weapons[0].SetActive(false);
        Weapons[1].SetActive(true);
        Weapons[2].SetActive(false);
    }

    void ChangeToThree()
    {
        Weapons[0].SetActive(false);
        Weapons[1].SetActive(false);
        Weapons[2].SetActive(true);
    }
}
