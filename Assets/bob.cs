﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob : MonoBehaviour
{
    public AnimationCurve ac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ac.Evaluate((Time.time % ac.length)) + 9f, transform.position.z);
    }
}
