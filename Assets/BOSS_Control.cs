using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("BOSS����")]
    public GameObject[] skillPrefab;

    public float stopTime;//��¼BOSS���ι���֮��ļ��



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
}
