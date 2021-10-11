using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private BoxCollider2D coll;
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 speedDir;


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

   

    private void FixedUpdate()
    {
        /*Vector3 difference = Input.mousePosition;
        Vector3 original = new Vector3(weapon.transform.position.x, weapon.transform.position.y, weapon.transform.position.z);
        float cos = (difference.x - original.x) / Mathf.Sqrt((difference.x - original.x) * (difference.x - original.x) + (difference.y - original.y) * (difference.y - original.y));
        float sin=(difference.y-original.y)/ Mathf.Sqrt((difference.x - original.x) * (difference.x - original.x) + (difference.y - original.y) * (difference.y - original.y));
        //transform.eulerAngles = new Vector3(0, 0, rotZ);
        //rb.velocity=(new Vector3(difference.x - Camera.main.pixelWidth / 2, difference .y - Camera.main.pixelHeight / 2, 0).normalized * speed);
        rb.velocity = new Vector3(speed * cos, speed * sin);*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.transform.tag=="wall")
        {
            Destroy(transform.gameObject);
        }
    }
}
