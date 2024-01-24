using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeplacement : MonoBehaviour
{
    public Animator animator;
    public bool doubleSaut = true;
    public bool canDoubleJump = true;
    public bool dash = true;
    public bool isDashing = false;
    public bool canDash = true;
    public float startTime = 0.0f;
    public bool dialogue = false;

    void Update()
    {
        if (!dialogue)
        {
            game();
        }
    }

    public void SetDialogue(bool booléen)
    {
        dialogue = booléen;
    }


    // Update is called once per frame
    void game()
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
            canDash = true;
        } 
        else
        {
            animator.SetBool("Jump", true);
        }

        audioSauts audio = GetComponent<audioSauts>();

        if (Input.GetButtonDown("Jump") && GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>())) 
        {
            if (!isDashing) 
            {
                audio.playSound1();
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
            }
        } 

    
        if (doubleSaut) 
        {
            if (Input.GetButtonDown("Jump") && !GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>()) && canDoubleJump) 
            {
                if (!isDashing) 
                {
                    audio.playSound2();
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
                    canDoubleJump = false;
                }
            }
        }

        

        if (dash) 
        {
            if (Input.GetButtonDown("Dash") && !isDashing && canDash)
            {
                isDashing = true;
                animator.SetBool("isDashing", true);
                startTime = Time.time;
                audio.playSound3();
            }

            if (isDashing)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                if (!GetComponent<SpriteRenderer>().flipX)
                {
                    transform.Translate(new Vector3(1, 0, 0) * 20 * Time.deltaTime);
                } else {
                    transform.Translate(new Vector3(-1, 0, 0) * 20 * Time.deltaTime);
                }
                
                if (Time.time - startTime >= 0.3f)
                {
                    isDashing = false;
                    canDash = false;
                    animator.SetBool("isDashing", false);
                }
            }
            
        }
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if (!isDashing)
        {
            transform.Translate(new Vector3(horizontal, 0, 0) * Mathf.Abs(horizontal) * 10 * Time.deltaTime);
        }
    }
}
