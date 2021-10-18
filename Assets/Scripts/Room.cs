using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public static Room instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;//判断上下左右是否有房间

    public GameObject nextLevelDoor;//传送门
    int nextLevelDoorNum;//记录个数，防止多次生成

    public int stepToStart;//决定房间的难易程度

    public int enemyNum;//判断敌人数量,在门的控制里调用，控制门的开关

    public Text text;

    public int doorNum;

    public Collider2D coll;

    private doorControl dc;

    private playerControl player;

    private RoomGenerator rg;

    private SpriteRenderer sr;
    
    Vector2 MinPos;//房间最左侧的位置
    Vector2 MaxPos;//房间最右侧的位置

    


    //随机生成敌人
    public List<GameObject> enemys = new List<GameObject>();
    bool noInitedEnemy=true;

    
    //随机生成宝箱
    public GameObject[] Awards;//0是每个房间的奖励盒子
    public bool noInitedBox=true;
    GameObject Box;

    //生成奖励物品
    public GameObject[] AwardObjects;//0是能量值
    bool noInitedAwardObject1=true;

    //存放BOSS预制体
    public GameObject BOSSPrefab;

    //记录当前场景编号，最后一个场景的最后一个房间生成BOSS而不是传送门
    int index;

    void Start()
    {
        dc = GetComponentInChildren<doorControl>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<playerControl>();
        rg = GameObject.Find("RoomGenerator").GetComponent<RoomGenerator>();
        //每个房间的长为16，宽为8
        MinPos = new Vector2(transform.position.x - 8f, transform.position.y);
        MaxPos = new Vector2(transform.position.x + 8f, transform.position.y);



        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);

        enemyNum = 2 * stepToStart;
        // Debug.Log("这是怪物数量"+enemyNum);

        //获取当前场景编号，最后一个场景的最后一个房间生成BOSS而不是传送门
        index = SceneManager.GetActiveScene().buildIndex;


    }

    
    void Update()
    {
       // Debug.Log(player.transform.position.x);
       // Debug.Log(InitAwards() + "这是奖励盒子的位置");
    }
    private void FixedUpdate()
    {
        if(noInitedBox)
        {
            BoxPos(out Box);
        }

        GetAwards(Box);
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
        if (enemyNum == 0) 
        { 
            dc.OpenDoors();//开门
        }
        

    }

    public void BoxPos(out GameObject Box)
    {
        if (enemyNum == 0 && stepToStart != 0 && noInitedBox)
        {
            Debug.Log("生成了盒子");
            Box = Instantiate(Awards[0], new Vector2(Random.Range(MinPos.x, MaxPos.x), Random.Range(MinPos.y - 3f, MinPos.y + 3f)), Quaternion.identity);
            noInitedBox = false;
            //Debug.Log(Box.transform.position + "这是盒子的位置");
        }
        else Box = null;

    }


    public void GetAwards(GameObject Box)//在生成奖励盒子周边的一定区域内打开奖励盒子
    {
        if (Box != null)
        {
            if (Mathf.Abs(Box.transform.position.x - player.transform.position.x) < 1f && Mathf.Abs(Box.transform.position.y - player.transform.position.y) < 1f && noInitedAwardObject1)
            {
                Debug.Log("即将生成宝珠");

                Destroy(Box.transform.gameObject);//生成宝珠的同时，销毁盒子

                GameObject gems= Instantiate(AwardObjects[0], new Vector2(Random.Range(Box.transform.position.x - 0.5f, Box.transform.position.x + 0.5f), Random.Range(Box.transform.position.y - 0.5f, Box.transform.position.y + 0.5f)), Quaternion.identity);
                
                noInitedAwardObject1 = false;

                //吸引效果用的插件

                //接触到玩家之后，能量珠销毁
                if (Mathf.Abs(gems.transform.position.x- player.transform.position.x)<2f&&Mathf.Abs(gems.transform.position.y - player.transform.position.y)<2f)
                {
                    Debug.Log("距离可以了");
                    Destroy(gems.transform.gameObject,0.2f);
                    //玩家吃到能量珠，蓝条恢复
                    if(player.magicNum<player.MaxMagic)
                        player.magicNum += 16;
                    if (player.magicNum >= player.MaxMagic)
                        player.magicNum = player.MaxMagic;
                }

            }
        }
    }

    //生成怪物的方法
    void inite()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            int index = Random.Range(0, enemys.Count);//记录生成哪个怪物

            GameObject enemy = Instantiate(enemys[index], new Vector2(Random.Range(MinPos.x+1f, MaxPos.x-1f), Random.Range(MinPos.y - 3f, MinPos.y + 3f)), Quaternion.identity);

            enemy.GetComponent<EnemyAI>().room = this;
        }
    }

    //生成BOSS的方法
    void initBoss()
    {
        Instantiate(BOSSPrefab, transform.position, Quaternion.identity);
    }

    //生成怪物
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //获取的是房间的颜色，判断是不是最后一个房间,最后一个房间不生成怪物
        if (stepToStart != 0&&noInitedEnemy&&sr.color!=Color.red)
        {
            Invoke("inite", 1f);//进入房间后延时一秒生成怪物
            
            noInitedEnemy = false;

            if (enemyNum > 0)
            {
                dc.CloseTheDoor();
                Debug.Log("enemyNum=" + enemyNum);
            }
           
        }

        //生成传送门
        if(sr.color==Color.red&&nextLevelDoorNum==0&&index!=4)
        {
            Instantiate(nextLevelDoor, transform.position, Quaternion.identity);
            nextLevelDoorNum += 1;
        }

        //生成BOSS
        if(sr.color == Color.red&&noInitedEnemy && index== 4)
        {
            //生成BOSS
            Invoke("initBoss", 1.5f);
            noInitedEnemy = false;
        }

    }


}
