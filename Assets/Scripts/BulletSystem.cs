using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    public int attackForce;
    public float lifeTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
