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
        //ÏûÃðµÐÈË
        if (collision.gameObject.tag == "Bullet")
        {
            bullet _bullet = collision.gameObject.GetComponent<bullet>();
            int hurt = _bullet.attackForce;
            healthNum -= hurt;

            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            if (healthNum <= 0&&isAlive)
            {
               anim.SetBool("Die", true);
                room.enemyNum--;
                isAlive = false;
                room.DoorStateChange();
                Destroy(gameObject,0.1f);

            }
        }

       

        
    }
}
