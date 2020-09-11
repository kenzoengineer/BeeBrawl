using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Weapon weapon;
    public float speed = 1f;
    Color c = new Color(1f, 1f, 1f, 1f);
    float alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<LineRenderer>().material.SetColor("_TintColor", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CurrentWeapon.currentWeapon == 1 && weapon.ammo != 0) alpha = 1f;
        if (alpha > 0.0f) alpha -= Time.deltaTime * speed;

        c = new Color(1f, 1f, 1f, alpha);
        gameObject.GetComponent<LineRenderer>().material.SetColor("_TintColor", c);
    }
}
