using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : EnemyAI
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("移动参数")]
    public float speed;
    public float speedDir;

    [Header("攻击参数")]
    public int attackForce;//攻击力



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
}
