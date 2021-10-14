using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class playerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    public Animator anim;


    public int healthNum;
    public float speed;
    public float speed1;
    Vector2 movement;
    public Transform playerPrefab;
   

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        speed1 = speed;
    }

    
    void Update()
    {
        playerPrefab.position = transform.position;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x!=0)
        {
            rb.transform.localScale = new Vector3(movement.x, 1, 1);
        }

        switchAnim();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);



    }

    public void switchAnim()
    {
        anim.SetFloat("running", movement.magnitude-0.1f);
    }





}
