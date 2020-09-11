using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public Animator ani;
    public Weapon wp;

    private void Start() {
        ani.speed = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        if (wp.ammo != 0) ani.Play("ammoani", 0, (7 - wp.ammo) / 7.0f);
        else ani.Play("ammoani", 0, 0.99f);
    }
}
