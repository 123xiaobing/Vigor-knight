using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PigAI : EnemyAI
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField]private playerControl player;

    public int attackForce=1;//¹¥»÷Á¦

   


    Vector3 initPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>();

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        initPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //×ªÏò
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
            transform.position = initPosition;
        }
       
    }


    //¹¥»÷Íæ¼Ò
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<playerControl>();
            player.defenceNum -= attackForce;
            if (player.defenceNum < 0)
            {
                player.defenceNum = 0;
                player.healthNum -= attackForce;

                if (player.healthNum <= 0)
                {
                    player.anim.SetBool("die", true);
                    player.speed1 = 0;
                    Time.timeScale = 0;
                    //ÇÐ»»ËÀÍö»­Ãæ 
                }
            }
        }
    }
}
