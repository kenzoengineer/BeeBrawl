using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    public static int currentWeapon = 1;
    public GameObject pos;
    public SpriteRenderer sp;
    public SpriteRenderer bs;
    public SpriteRenderer hot;

    public Sprite w1;
    public Sprite w2;
    public Sprite w3;

    public Sprite h1;
    public Sprite h2;
    public Sprite h3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) {
            pos.GetComponent<SpriteRenderer>().enabled = true;
            currentWeapon = 1;
            sp.sprite = w1;
            hot.sprite = h1;
            bs.sprite = w3;
            //pos.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z);
        } else if (Input.GetKey(KeyCode.Alpha2)) {
            pos.GetComponent<SpriteRenderer>().enabled = true;
            currentWeapon = 2;
            sp.sprite = w2;
            hot.sprite = h2;
            bs.sprite = w3;
            //pos.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z);
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            currentWeapon = 3;
            pos.GetComponent<SpriteRenderer>().enabled = false;
            hot.sprite = h3;
            bs.sprite = w1;
        } else if (Input.GetKey(KeyCode.Alpha4)) {
            currentWeapon = 4;
        } else if (Input.GetKey(KeyCode.Alpha5)) {
            currentWeapon = 5;
        }
    }
}
