using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    public GameObject doorL, doorR, doorU, doorD;


    public Collider2D checkColl;


    int player;
    private void Start()
    {
        player = LayerMask.NameToLayer("Player");
        Debug.Log("开始");
        doorL.SetActive(false);
        doorR.SetActive(false);
        doorU.SetActive(false);
        doorD.SetActive(false);
    }

    void Update()
    {
        OpenDoors();
    }

    public void OpenDoors()//实现开门
    {
        if(Room.instance.enemyNum==0)
        {
            Debug.Log("怪物消失");
            doorL.SetActive(false);
            doorR.SetActive(false);
            doorU.SetActive(false);
            doorD.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)//实现关门
    {
        if(collision.gameObject.tag=="Player")/*&& Room.instance.enemyNum >0*/
        {
            Debug.Log("1");
            doorL.SetActive(Room.instance.roomLeft);
            doorR.SetActive(Room.instance.roomRight);
            doorU.SetActive(Room.instance.roomUp);
            doorD.SetActive(Room.instance.roomDown);
        }
    }
}
