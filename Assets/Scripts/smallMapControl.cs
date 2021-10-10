using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallMapControl : MonoBehaviour
{
    public GameObject smallMap;
    public GameObject smallPlayer;
    private bool mapIsOn=false;
    public playerControl player;
    
    private void Start()
    {
        smallMap.SetActive(mapIsOn);
        smallPlayer.SetActive(mapIsOn);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            mapIsOn = true;
            smallMap.SetActive(mapIsOn);
            smallPlayer.SetActive(mapIsOn);
            player.speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            mapIsOn = false;
            smallMap.SetActive(mapIsOn);
            smallPlayer.SetActive(mapIsOn);
            player.speed = player.speed1;
        }


    }
}
