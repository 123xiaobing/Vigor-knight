using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private BoxCollider2D coll;
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 speedDir;

    public int attackForce;

    /// <summary>
    /// �ܹ��ݻٵĶ���
    /// </summary>
    private PigAI pig;
    private GoblinAI goblin;


    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        

        // ��ȡ������겢ת������������
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        // ��Ϊ��2D���ò���z�ᡣʹ��z���ֵΪ0�����������������(x,y)ƽ������
        m_mousePosition.z = 0;

        rb.velocity = ((m_mousePosition - transform.position).normalized * speed);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {

            Destroy(gameObject);
        }
        //�������
        if(collision.gameObject.tag=="EnemyPig")
        {
            pig =collision.gameObject.GetComponent<PigAI>();
            pig.healthNum-=attackForce;
            Destroy(gameObject);
            if (pig.healthNum == 0)
            {
                pig.anim.SetBool("pigDie", true);
                Destroy(collision.gameObject, 0.1f);
                Destroy(gameObject);
                Room.instance.enemyNum--;
            }
        }

        if (collision.gameObject.tag == "EnemyGoblin")
        {
            goblin = collision.gameObject.GetComponent<GoblinAI>();
            goblin.healthNum-=attackForce;
            Destroy(gameObject);
            if (goblin.healthNum == 0)
            {
                goblin.anim.SetBool("goblinDie", true);
                Destroy(collision.gameObject, 0.1f);
                Destroy(gameObject);
                Room.instance.enemyNum--;
            }
           
        }

        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }

    }
   


}
