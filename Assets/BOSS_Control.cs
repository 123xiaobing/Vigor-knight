using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("BOSS大招")]
    public GameObject[] skillPrefab;

    public float stopTime;//记录BOSS两次攻击之间的间隔



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
}
