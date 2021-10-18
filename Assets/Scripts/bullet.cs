using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private BoxCollider2D coll;
    public Rigidbody2D rb;
    public Room room;
    [SerializeField] private float speed;
    private Vector2 speedDir;

    public int attackForce;//������

    private float lifeTime=3;

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
    private void OnEnable()
    {


        lifeTime = 3;
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        // ��Ϊ��2D���ò���z�ᡣʹ��z���ֵΪ0�����������������(x,y)ƽ������
        m_mousePosition.z = 0;



        // �ٶ�
        rb.velocity = transform.right * speed;

       
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            transform.gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        //������ƻ���
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            //Destroy(gameObject);
            
        }

    }
   


}
