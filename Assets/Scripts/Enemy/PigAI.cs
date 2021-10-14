using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PigAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Animator anim;
    public playerControl player;


    [Header("移动参数")]
    public float speed;
    public float speedDir;

    [Header("攻击参数")]
    public int attackForce=1;//攻击力


    public int healthNum=2;//生命


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        
       // player = GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //转向
        if(player.transform.position.x>=transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if(player.transform.position.x<transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x-player.transform.position.x)>18&&Mathf.Abs(transform.position.y - player.transform.position.y)>10)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }


    //攻击玩家
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.healthNum -= attackForce;
            if(player.healthNum<=0)
            {
                player.anim.SetBool("die", true);
                Destroy(collision.gameObject);

                //切换死亡画面 
            }
        }
    }
}
