using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    public Animator anim;

    [Header("玩家属性")]
    public int healthNum;
    public int MaxHealth;
    public int magicNum;
    public int MaxMagic;
    public int defenceNum;//三秒+1
    public int MaxDefence;

    long stopTime = -3;

    public float speed;
    public float speed1;
    Vector2 movement;

    public Transform playerPrefab;//用于记录玩家的位置，让怪物实现自动寻路

    public LayerMask TransferGate;//记录传送门的图层

    bool beAttacked = true;//记录是否被BOSS攻击
    float beAttackedDuringTime = 0.1f;//每0.1s将beAttacked改成true;
    float NowTime;

    public GameObject NextLevelBtn;

    void Start()
    {
        NowTime = Time.realtimeSinceStartup;
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        
        speed1 = speed;
        
        healthNum = MaxHealth;
        magicNum = MaxMagic;
        defenceNum = MaxDefence;
    }

    
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x!=0)
        {
            rb.transform.localScale = new Vector3(movement.x, 1, 1);
        }

        switchAnim();

        DefenceNumAdd();//护甲自动回复
        
        Transfer();//传送


        //每隔0.1s将beAttacked重置
        if(Time.realtimeSinceStartup-NowTime>beAttackedDuringTime)
        {
            beAttacked = true;
            NowTime += beAttackedDuringTime;
        }

    }
    private void FixedUpdate()
    {
        playerPrefab.position = transform.position;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);



    }

    public void switchAnim()
    {
        anim.SetFloat("running", movement.magnitude-0.1f);
    }



    //护甲自动回复
    public void DefenceNumAdd()
    {
        if (defenceNum == MaxDefence)
            stopTime = (long)Time.time;

        if(Time.time-stopTime>3f&&defenceNum<MaxDefence)
        {
            stopTime += 3;
            defenceNum += 1;
        }
    }

    //传送门
    void Transfer()
    {
        if(coll.IsTouchingLayers(TransferGate))
        {
            //按E提示进入下一关
            if (Input.GetKey(KeyCode.E))
                NextLevelBtn.SetActive(true);
                
        }
    }



    int temp;//记录BOSS伤害消除护甲后剩余的伤害
    //BOSS伤害
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="BossSkill")//BOSS的第一个大招每个“子弹”3点伤害
        {
            collision.gameObject.SetActive(false);

                if (defenceNum > 0)
                {
                    if (defenceNum >= 3&& beAttacked)
                    {
                        defenceNum -= 3;
                        Debug.Log("生命值-3");
                        beAttacked = false;
                    }

                    if (defenceNum < 3&& beAttacked)
                    {
                        temp = 3 - defenceNum;
                        defenceNum = 0;
                        healthNum -= temp;
                        Debug.Log("生命值-" + temp);
                        if (healthNum <= 0)
                        {
                            healthNum = 0;//刷新生命值
                            anim.SetBool("die", true);
                            Time.timeScale = 0;
                        }
                        beAttacked = false;
                    }
                }
                if (defenceNum <= 0&& beAttacked)
                {
                    healthNum -= 3;
                    Debug.Log("生命值又-3");
                    if (healthNum <= 0)
                    {
                        healthNum = 0;//刷新生命值
                        anim.SetBool("die", true);
                        Time.timeScale = 0;

                    }
                    beAttacked = false;
                }
        }

        //地刺陷阱
        if (collision.gameObject.tag == "SandBox")
        {
            if (defenceNum > 0)
                defenceNum--;
            if (defenceNum <= 0)
            {
                healthNum--;
                if (healthNum <= 0)
                {
                    anim.SetBool("die", true);
                    Time.timeScale = 0;
                }
            }
        }
    }
}
