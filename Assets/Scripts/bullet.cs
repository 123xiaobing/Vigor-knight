using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private BoxCollider2D coll;
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 speedDir;
   


    /// <summary>
    /// 能够摧毁的对象
    /// </summary>
    private PigAI pig;
    private GoblinAI goblin;


    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        

        // 获取鼠标坐标并转换成世界坐标
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        m_mousePosition.z = 0;

        rb.velocity = ((m_mousePosition - transform.position).normalized * speed);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {

            Destroy(gameObject);
        }

        if(collision.gameObject.tag=="EnemyPig")
        {
            pig =collision.gameObject.GetComponent<PigAI>();
            pig.anim.SetBool("pigDie", true);
            Destroy(collision.gameObject,0.1f);
            Destroy(gameObject);
            Room.instance.enemyNum--;
        }

        if (collision.gameObject.tag == "EnemyGoblin")
        {
            goblin = collision.gameObject.GetComponent<GoblinAI>();
            goblin.anim.SetBool("goblinDie", true);
            Destroy(collision.gameObject, 0.1f);
            Destroy(gameObject);
            Room.instance.enemyNum--;
        }

    }
}
