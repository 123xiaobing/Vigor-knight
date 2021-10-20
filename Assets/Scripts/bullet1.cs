using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    private Collider2D coll;
    public Rigidbody2D rb;

    [SerializeField] private float speed;
    private Vector2 dir;

    public int attackForce;//攻击力

    private float lifeTime=3;


    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
       
        // 获取鼠标坐标并转换成世界坐标
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);

        m_mousePosition.z = 0;

        rb.velocity = ((m_mousePosition - transform.position).normalized * speed);



    }
    //private void OnEnable()
    //{




    //    //Vector3 m_mousePosition = Input.mousePosition;
    //    //m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
    //    //// 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
    //    //m_mousePosition.z = 0;
    //    //rb.velocity = ((m_mousePosition - transform.position).normalized * speed);

    //}

    private void Update()
    {
        

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
            //BulletsPool.bulletsPoolInstance.Recycle(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {
           // BulletsPool.bulletsPoolInstance.Recycle(gameObject);
            
            Destroy(gameObject);
        }

        //清楚可破坏物
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //BulletsPool.bulletsPoolInstance.Recycle(gameObject);
            //Destroy(gameObject);
            
        }

    }
   


}
