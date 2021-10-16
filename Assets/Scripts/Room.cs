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

    public int enemyNum;//在枪里面调用，判断敌人数量,在门的控制里调用，控制门的开关

    public Text text;

    public int doorNum;

    public Collider2D coll;

    private doorControl dc;
    
    Vector2 roomPos;//当前房间的位置（都是中心点）
    Vector2 MinPos;//房间最左侧的位置
    Vector2 MaxPos;//房间最右侧的位置

    //随机生成敌人
    public List<GameObject> enemys = new List<GameObject>();
    bool hasInited=true;

    /// <summary>
    /// 待做
    /// </summary>
    //随机生成宝箱
    public GameObject[] Awards;
   

    void Start()
    {
        dc = GetComponentInChildren<doorControl>();
        roomPos = transform.position;//每个房间的长为16，宽为8
        MinPos = new Vector2(transform.position.x - 8f, transform.position.y);
        MaxPos = new Vector2(transform.position.x + 8f, transform.position.y);



        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);

        enemyNum = 2 * stepToStart;
       // Debug.Log("这是怪物数量"+enemyNum);


    }

    
    void Update()
    {
        
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

    public void DoorStateChange()
    {
        if (enemyNum == 0) dc.OpenDoors();

    }

    //生成怪物,测试先生成4个怪
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (stepToStart != 0&&hasInited)
        {
            for (int i = 0; i< enemyNum; i++) 
            {
                int index = Random.Range(0, enemys.Count);//记录生成哪个怪物
                GameObject enemy = Instantiate(enemys[index], new Vector2(Random.Range(MinPos.x, MaxPos.x), Random.Range(MinPos.y - 4f, MinPos.y + 4f)), Quaternion.identity);
                enemy.GetComponent<EnemyAI>().room = this;
            }
            hasInited = false;
            if (enemyNum > 0)
            {
                dc.CloseTheDoor();
                Debug.Log("enemyNum=" + enemyNum);
            }
           


        }


    }
}
