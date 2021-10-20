using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Room room;
    public Animator anim;
    public int healthNum = 2;
    public bool isAlive=true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //消灭敌人
        if (collision.gameObject.tag == "Bullet")
        {
            bullet1 _bullet = collision.gameObject.GetComponent<bullet1>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;

            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            Destroy(collision.gameObject);
            if (healthNum <= 0&&isAlive)
            {
                anim.SetBool("Die", true);
                room.enemyNum--;
                isAlive = false;
                room.DoorStateChange();
                Destroy(gameObject,0.1f);

            }
        }
        if (collision.gameObject.tag == "Bullet1")
        {
            bullet2 _bullet = collision.gameObject.GetComponent<bullet2>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;

            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            Destroy(collision.gameObject);
            if (healthNum <= 0 && isAlive)
            {
                anim.SetBool("Die", true);
                room.enemyNum--;
                isAlive = false;
                room.DoorStateChange();
                Destroy(gameObject, 0.1f);

            }
        }

        //第三把枪
        if (collision.gameObject.tag == "Bullet2")
        {
            bullet3 _bullet = collision.gameObject.GetComponent<bullet3>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;

            //BulletsPool.bulletsPoolInstance.Recycle(collision.gameObject);
            Destroy(collision.gameObject);
            if (healthNum <= 0 && isAlive)
            {
                anim.SetBool("Die", true);
                room.enemyNum--;
                isAlive = false;
                room.DoorStateChange();
                Destroy(gameObject, 0.1f);

            }
        }

        //地刺
        if (collision.gameObject.tag == "SandBox")
        {
            healthNum -= 1;
            if (healthNum <= 0 && isAlive)
            {
                anim.SetBool("Die", true);
                room.enemyNum--;
                isAlive = false;
                room.DoorStateChange();
                Destroy(gameObject, 0.1f);

            }

        }

    }
}
