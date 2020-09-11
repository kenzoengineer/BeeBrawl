using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float hangTime = 0.4f;
    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, hangTime);
    }
}
