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

    [Header("�������")]
    public int healthNum;
    public int MaxHealth;
    public int magicNum;
    public int MaxMagic;
    public int defenceNum;//����+1
    public int MaxDefence;

    long stopTime = -3;

    public float speed;
    public float speed1;
    Vector2 movement;

    public Transform playerPrefab;//���ڼ�¼��ҵ�λ�ã��ù���ʵ���Զ�Ѱ·

    public LayerMask TransferGate;//��¼�����ŵ�ͼ��

    bool beAttacked = true;//��¼�Ƿ�BOSS����
    float beAttackedDuringTime = 0.1f;//ÿ0.1s��beAttacked�ĳ�true;
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

        DefenceNumAdd();//�����Զ��ظ�
        
        Transfer();//����


        //ÿ��0.1s��beAttacked����
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



    //�����Զ��ظ�
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

    //������
    void Transfer()
    {
        if(coll.IsTouchingLayers(TransferGate))
        {
            //��E��ʾ������һ��
            if (Input.GetKey(KeyCode.E))
                NextLevelBtn.SetActive(true);
                
        }
    }



    int temp;//��¼BOSS�˺��������׺�ʣ����˺�
    //BOSS�˺�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="BossSkill")//BOSS�ĵ�һ������ÿ�����ӵ���3���˺�
        {
            collision.gameObject.SetActive(false);

                if (defenceNum > 0)
                {
                    if (defenceNum >= 3&& beAttacked)
                    {
                        defenceNum -= 3;
                        Debug.Log("����ֵ-3");
                        beAttacked = false;
                    }

                    if (defenceNum < 3&& beAttacked)
                    {
                        temp = 3 - defenceNum;
                        defenceNum = 0;
                        healthNum -= temp;
                        Debug.Log("����ֵ-" + temp);
                        if (healthNum <= 0)
                        {
                            healthNum = 0;//ˢ������ֵ
                            anim.SetBool("die", true);
                            Time.timeScale = 0;
                        }
                        beAttacked = false;
                    }
                }
                if (defenceNum <= 0&& beAttacked)
                {
                    healthNum -= 3;
                    Debug.Log("����ֵ��-3");
                    if (healthNum <= 0)
                    {
                        healthNum = 0;//ˢ������ֵ
                        anim.SetBool("die", true);
                        Time.timeScale = 0;

                    }
                    beAttacked = false;
                }
        }

        //�ش�����
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
