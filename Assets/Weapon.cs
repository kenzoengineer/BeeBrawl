using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fP;
    public GameObject impactEffect;
    public SpriteRenderer underlay;
    public LineRenderer lr;
    public AudioClip audioClip;
    public AudioClip reload;
    public LayerMask lm;
    public float hangTime = 0.1f;

    public int ammo = 7;
    public float delay = 0.75f;
    Vector3 mousePos;
    public bool reloading;

    float time;

    void Start() {
        lr.enabled = true;
        reloading = false;
        time = Time.time;
    }

    // Update is called once per frame
    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        //Debug.DrawRay(fP.transform.position, mousePos * 100, Color.red, 0.01f);
        //Debug.DrawRay(fP.position, mousePos - fP.position, Color.red, 0.01f);

        if (Time.time - time >= delay && ammo != 0 && !reloading) {
            underlay.color = new Color(87f / 255f, 197f / 255f, 92f / 255f);
        } else {
            underlay.color = new Color(205f / 255f, 88f / 255f, 107f / 255f);
        }

        if (Input.GetButtonDown("Fire1") && CurrentWeapon.currentWeapon == 1 && Time.timeScale > 0 && ammo > 0 && Time.time - time >= delay && !reloading) {
            ammo -= 1;
            Shoot();
            time = Time.time;
        }

        if (ammo == 0) {
            if (!reloading) {
                reloading = true;
                StartCoroutine(Reload());
            }
        }

        if (Input.GetButtonDown("Reload") && ammo != 7) {
            if (!reloading) {
                reloading = true;
                StartCoroutine(Reload());
            }
        }
    }

    void Shoot() {
        RaycastHit2D hitInfo = Physics2D.Raycast(fP.position, mousePos - fP.position, 100f, ~lm);
        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            //Debug.Log(mousePos.x + " " + mousePos.y);

            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            lr.SetPosition(0, fP.position);
            lr.SetPosition(1, hitInfo.point);
        }
        else {
            Vector3 v = (10 * (mousePos - fP.position)) + mousePos;
            v.z = Camera.main.nearClipPlane;
            lr.SetPosition(0, fP.position);
            lr.SetPosition(1, v);
        }

        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    IEnumerator Reload() {
        underlay.color = new Color(205f / 255f, 88f / 255f, 107f / 255f);
        yield return new WaitForSeconds(0.5f);
        AudioSource.PlayClipAtPoint(reload, transform.position);
        yield return new WaitForSeconds(1.0f);
        ammo = 7;
        reloading = false;
    }
}
