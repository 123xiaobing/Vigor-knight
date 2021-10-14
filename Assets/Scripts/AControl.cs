using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AControl : MonoBehaviour
{
    public GameObject Astar;
    public Rigidbody2D rb;
    private float stopTime=1f;

    
    void Start()
    {
        Astar.SetActive(false);
        
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad>stopTime)
        {
            Astar.SetActive(true);
            
        }

    }
}
