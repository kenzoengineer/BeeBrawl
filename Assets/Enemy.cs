using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 20;
    public GameObject deathEffect;
    public Camera zoomCam;

    void Start() {
        Vector3 force = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f),0);
        gameObject.GetComponent<Rigidbody2D>().velocity = force;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Player")) {
            Debug.Log("touched");
            Time.timeScale = 0;
            float x = GameObject.FindWithTag("Player").transform.position.x;
            float y = GameObject.FindWithTag("Player").transform.position.y;
            Instantiate(zoomCam, new Vector3(x,y,-10f), Quaternion.identity);
        }*/

        /*
        if (other.CompareTag("Player") && !damaged) {
            print("touched");
            GameObject player = other.gameObject;
            player.GetComponent<HP>().TakeDamage(20);
            damaged = false;
            Die();
        }
        */
    }

    public void TakeDamage(int dmg) {
        hp -= dmg;

        if (hp <= 0) {
            Die();
        }

    }

    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
