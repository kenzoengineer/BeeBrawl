using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject e;
    int timer = 0;
    bool stop = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) {
            stop = !stop;
        }

        if (Time.timeScale == 0) stop = true;

        timer++;
        if (timer > 100 && !stop) {
            Spawn();
            timer = 0;
        }
    }

    void Spawn() {
        Instantiate(e, new Vector3(Random.Range(-5f, 5f), 15f, 0), Quaternion.identity);
    }
}
