using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : EnemyAI
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("�ƶ�����")]
    public float speed;
    bool isleft=false;
    bool isup=true;
    [SerializeField] private GameObject L_point, R_point, U_point, D_point;

    [Header("��������")]
    public int attackForce;//������

    [SerializeField] private LayerMask wall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        transform.DetachChildren();//�����������ұ�ǵ�
    }

    private void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        if (isleft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < L_point.transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector3(1, 1, 1);
                isleft = false;
                if (coll.IsTouchingLayers(wall))
                    speed = -speed;
            }
        }
        if (!isleft)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > R_point.transform.position.x)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
                isleft = true;
                if (coll.IsTouchingLayers(wall))
                    speed = -speed;
            }
        }

        //if (!isup)
        //{
        //    if (transform.position.y < D_point.transform.position.y)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, speed);
        //        isup = true;
        //        if (coll.IsTouchingLayers(wall))
        //            speed = -speed;
        //    }
        //}
        //if (isup)
        //{
        //    if (transform.position.y > D_point.transform.position.y)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, -speed);
        //        if (coll.IsTouchingLayers(wall))
        //            speed = -speed;
        //    }
        //}

        
    }
}
