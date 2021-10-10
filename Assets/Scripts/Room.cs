using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;//判断上下左右是否有房间

    public int stepToStart;

    public Text text;

    public int doorNum;
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }

    
    void Update()
    {
        
    }

    public void UpdateRoom(float xOffset,float yOffset)
    {
        doorNum=0;
        stepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));
        text.text = stepToStart.ToString();
        if (roomUp)
        {
            doorNum++;
           // Debug.Log("Up");
        }
        if (roomDown)
        {
            doorNum++;
           // Debug.Log("Down");
        }
        if (roomLeft)
        {
            doorNum++;
            //Debug.Log("Left");
        }
        if (roomRight)
        {
            doorNum++;
            //Debug.Log("Right");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CameraControl.instance.changeTarget(transform);
        }

    }
}
