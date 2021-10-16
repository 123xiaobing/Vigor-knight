using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : EnemyAI
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("�ƶ�����")]
    public float speed;
    public float speedDir;

    [Header("��������")]
    public int attackForce;//������



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
}
