using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    public GameObject doorL, doorR, doorU, doorD;

    public Collider2D checkColl;

    public playerControl player;

    public Room room;

    private void Start()
    {
        //room = GameObject.Find("Room").GetComponent<Room>();

        Debug.Log("开始");
        doorL.SetActive(false);
        doorR.SetActive(false);
        doorU.SetActive(false);
        doorD.SetActive(false);
    }


    public void OpenDoors()//实现开门
    {
        Debug.Log("怪物消失");
        doorL.SetActive(false);
        doorR.SetActive(false);
        doorU.SetActive(false);
        doorD.SetActive(false);
    }

    public void CloseTheDoor()//实现关门
    {
        Debug.Log("关门");
        if (room.roomLeft)
            doorL.SetActive(true);
        if (room.roomRight)
            doorR.SetActive(true);
        if (room.roomUp)
            doorU.SetActive(true);
        if (room.roomDown)
            doorD.SetActive(true);

    }

}
