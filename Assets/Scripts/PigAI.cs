using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("�ƶ�����")]
    public float speed;
    public float speedDir;

    [Header("��������")]
    public int attackForce;//������


    public int healthNum;//����


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
