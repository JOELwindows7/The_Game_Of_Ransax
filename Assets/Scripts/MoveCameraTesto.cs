﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraTesto : MonoBehaviour
{
    public float Speedt = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * Speedt;

        //Wait. why not move whole scene instead?
        //wouldn't that be simpler and tidier?!
    }
}
