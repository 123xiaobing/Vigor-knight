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

        Debug.Log("��ʼ");
        doorL.SetActive(false);
        doorR.SetActive(false);
        doorU.SetActive(false);
        doorD.SetActive(false);
    }


    public void OpenDoors()//ʵ�ֿ���
    {
        Debug.Log("������ʧ");
        doorL.SetActive(false);
        doorR.SetActive(false);
        doorU.SetActive(false);
        doorD.SetActive(false);
    }

    public void CloseTheDoor()//ʵ�ֹ���
    {
        Debug.Log("����");
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
