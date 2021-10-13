using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public static Room instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;//判断上下左右是否有房间

    public int stepToStart;//决定房间的难易程度

    public int enemyNum;//在枪里面调用，判断敌人数量

    public Text text;

    public int doorNum;

   

    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);

        enemyNum = 2 * stepToStart;


    }

    
    void Update()
    {
       // changeDoorState();
    }

    public void UpdateRoom(float xOffset,float yOffset)
    {
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

    //决定门的开关
    //public void changeDoorState()
    //{
    //    if (this.enemyNum == 0)//如果敌人全部死亡，开门
    //    {
    //        this.doorDown.SetActive(false);
    //        this.doorLeft.SetActive(false);
    //        this.doorRight.SetActive(false);
    //        this.doorUp.SetActive(false);

    //    }

       
    //}




    //private void OnTriggerEnter2D(Collider2D other)//镜头移动——》废弃
    //{
    //    if(other.CompareTag("Player"))
    //    {
            
    //    }

    //}



}
