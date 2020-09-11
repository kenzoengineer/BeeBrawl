using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Animator animator;
    public Transform swingPoint;
    public LayerMask lm;
    bool swinging;
    public float rad;

    private void Start() {
        swinging = false;
    }

    // Update is called once per frame
    void Update() {
        if (CurrentWeapon.currentWeapon == 3) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetButtonDown("Fire1") && !swinging) {
                swinging = true;
                StartCoroutine(Swing());
            }
        } else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnDrawGizmos() {
        if (swinging) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(swingPoint.position, rad);
    }

    IEnumerator Swing() {
        animator.SetBool("swinging", true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swingPoint.position, rad, lm);
        foreach (Collider2D e in hitEnemies) {
            e.gameObject.GetComponent<Enemy>().TakeDamage(20);
        }

        yield return new WaitForSeconds(0.3f);
        animator.SetBool("swinging", false);
        swinging = false;
    }
}
