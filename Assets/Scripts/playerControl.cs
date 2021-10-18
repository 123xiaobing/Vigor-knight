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
    
    

    void Start()
    {
        
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
        playerPrefab.position = transform.position;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x!=0)
        {
            rb.transform.localScale = new Vector3(movement.x, 1, 1);
        }

        switchAnim();

        DefenceNumAdd();//护甲自动回复
        
        Transfer();//传送

    }
    private void FixedUpdate()
    {
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


    void Transfer()
    {
        if(coll.IsTouchingLayers(TransferGate))
        {
            //按E进入下一关
            if (Input.GetKey(KeyCode.E))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
