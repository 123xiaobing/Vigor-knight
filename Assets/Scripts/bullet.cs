using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private BoxCollider2D coll;
    public LayerMask wallLayer;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();

    }

   
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.transform.tag=="wall")
        {
            Destroy(transform.gameObject);
        }
    }
}
