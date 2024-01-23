using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ScriptDeplacement : MonoBehaviour
{
    public Animator animator;
    public bool doubleSaut = true;
    public bool canDoubleJump = true;
    public bool dash = true;
    public bool isDashing = false;
    public float startTime = 0.0f;
    public bool fusRohDah = false;


    // Update is called once per frame
    void Update()
    {
        // Pour se retourner
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        animator.SetFloat("Speed", 0);

        if (horizontal > 0 || horizontal < 0) 
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal) * 10);
        }

        if (GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>()) && !Input.GetButtonDown("Jump")) {
            animator.SetBool("Jump", false);
            canDoubleJump = true;
        } 
        else
        {
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Jump") && GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>())) 
        {
            if (!isDashing) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
            }
        } 

    
        if (doubleSaut) 
        {
            if (Input.GetButtonDown("Jump") && !GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>()) && canDoubleJump) 
            {
                if (!isDashing) 
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
                    canDoubleJump = false;
                }
            }
        }

        

        if (dash) 
        {
            if (Input.GetButtonDown("Dash") && !isDashing)
            {
                isDashing = true;
                animator.SetBool("isDashing", true);
                startTime = Time.time;
            }

            if (isDashing)
            {
                if (!GetComponent<SpriteRenderer>().flipX)
                {
                    transform.Translate(new Vector3(1, 0, 0) * 20 * Time.deltaTime);
                } else {
                    transform.Translate(new Vector3(-1, 0, 0) * 20 * Time.deltaTime);
                }
                
                if (Time.time - startTime >= 0.4f)
                {
                    isDashing = false;
                    animator.SetBool("isDashing", false);
                }
            }
            
        }

        if (!isDashing)
        {
            transform.Translate(new Vector3(horizontal, 0, 0) * Mathf.Abs(horizontal) * 10 * Time.deltaTime);
        } 
    }
}
