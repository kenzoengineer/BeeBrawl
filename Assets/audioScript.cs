using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    public AudioClip aClip;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("triggered");
        if (other.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(aClip, transform.position);
            Debug.Log("touched");
        }
    }
}
