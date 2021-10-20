using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    private Collider2D coll;
    public Rigidbody2D rb;

    [SerializeField] private float speed;

    public int attackForce;//������

    private float lifeTime = 3;


    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();



        // ��ȡ������겢ת������������
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        m_mousePosition.z = 0;

        rb.velocity = ((m_mousePosition -transform.position).normalized * speed);



    }


    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
     
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        //������ƻ���
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //Destroy(gameObject);

        }

    }
   
}
