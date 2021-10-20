using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;


    [Header("BOSS大招")]
    public GameObject[] skillPrefab;

    public float stopTime;//记录BOSS两次攻击之间的间隔
    public float healthNum;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //消灭敌人
        if (collision.gameObject.tag == "Bullet")
        {
            bullet1 _bullet = collision.gameObject.GetComponent<bullet1>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;
            Destroy(collision.gameObject);
            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            if (healthNum<=0)
            {
                anim.SetBool("Die", true);
                Destroy(gameObject, 0.2f);
            }
        }
        if (collision.gameObject.tag == "Bullet1")
        {
            bullet2 _bullet = collision.gameObject.GetComponent<bullet2>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;
            Destroy(collision.gameObject);
            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            if (healthNum <= 0)
            {
                anim.SetBool("Die", true);
                Destroy(gameObject, 0.2f);
            }
        }
        if (collision.gameObject.tag == "Bullet2")
        {
            bullet3 _bullet = collision.gameObject.GetComponent<bullet3>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;
            Destroy(collision.gameObject);
            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            if (healthNum <= 0)
            {
                anim.SetBool("Die", true);
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
