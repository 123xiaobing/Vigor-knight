using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{

    public GameObject destroyAble;

    void Start()
    {
        destroyAble.layer = LayerMask.NameToLayer("Destroyable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
