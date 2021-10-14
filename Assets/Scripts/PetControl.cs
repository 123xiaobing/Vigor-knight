using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControl : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private Animator anim;
    public playerControl player;
    private CircleCollider2D coll;
    public int attackForce;



    //可攻击对象
    private PigAI pig;
    private GoblinAI goblin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        SeekForPlayer();
        SwitchAnim();
    }

    //防止与玩家距离太远+转向
    void SeekForPlayer()
    {
        if(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2) > 81)
        {
            transform.position = player.transform.position;
        }
        if (player.transform.position.x >= transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    //改变动作
    void SwitchAnim()
    {
        if (Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2) <1)
        {
            anim.SetBool("running", false);
            coll.enabled = false;
        }
        else
        {
            anim.SetBool("running", true);
            coll.enabled = true;
        }
    }


    //攻击敌人
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyPig"))
        {
            pig.healthNum-=attackForce;
        }
        if(collision.CompareTag("EnemyGoblin"))
        {
            goblin.healthNum -= attackForce;
        }
    }

}
