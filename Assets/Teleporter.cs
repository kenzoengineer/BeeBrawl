using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    Vector3 mP;
    public LayerMask lm;
    public Sprite onSp;
    public Sprite offSp;
    public GameObject player;
    public GameObject sp;
    public GameObject tileMap;
    public LineRenderer lr;
    public Material mat;
    public bool on;
    public bool willCollide;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        willCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        on = CurrentWeapon.currentWeapon == 2 && Time.timeScale > 0;

        if (on) {
            sp.GetComponent<SpriteRenderer>().enabled = true;
            lr.enabled = true;
        }
        else {
            sp.GetComponent<SpriteRenderer>().enabled = false;
            lr.enabled = false;
        }

        mP = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        mP.z = 0;
        sp.transform.position = mP;

        RaycastHit2D hitInfo = Physics2D.Raycast(mP, new Vector3(0, -1, 0), 100f, ~lm);
        if (hitInfo)
        {
            lr.SetPosition(0, mP);
            lr.SetPosition(1, hitInfo.point);
        }
        else {
            lr.SetPosition(0, mP);
            lr.SetPosition(1, new Vector3(mP.x, mP.y - 100f, mP.z));
        }

        if (Input.GetButtonDown("Fire1") && on && !willCollide) {
            player.transform.position = mP;
        }

        if (sp.GetComponent<BoxCollider2D>().IsTouching(tileMap.GetComponent<Collider2D>()))
        {
            sp.GetComponent<SpriteRenderer>().sprite = offSp;
            willCollide = true;
        }
        else {
            sp.GetComponent<SpriteRenderer>().sprite = onSp;
            willCollide = false;
        }
    }

    float offset = 0f;
    private void FixedUpdate()
    {
        mat.mainTextureOffset = new Vector2(offset,0);
        offset -= 0.02f;
        if (offset <= -0.25f) offset = 0;
    }
}
