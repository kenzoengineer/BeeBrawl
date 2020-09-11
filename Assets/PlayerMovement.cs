using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Collider2D platforms;

    public float runSpeed = 40f;

    float hMove = 0f;
    bool jumping = false;
    bool crouching = false;


    void Update() {
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jumping = true;
            animator.SetBool("jumping", true);
        }

        animator.SetFloat("speed", Mathf.Abs(hMove));

        if (Input.GetButtonDown("Vertical")) {
            crouching = true;
            StartCoroutine(DisPlat());
        } else if (Input.GetButtonUp("Vertical")) {
            crouching = false;
        }
       
    }

    IEnumerator DisPlat()
    {
        platforms.enabled = false;
        yield return new WaitForSeconds(0.3f);
        platforms.enabled = true;
    }

    public void OnLanding() {
        animator.SetBool("jumping", false);
    }

    public void OnCrouch(bool crouch) {
        animator.SetBool("crouching", crouch);
    }
    
    void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime, crouching, jumping);
        jumping = false;
    }
}
