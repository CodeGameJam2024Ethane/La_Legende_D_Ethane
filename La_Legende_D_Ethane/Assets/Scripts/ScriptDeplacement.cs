using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ScriptDeplacement : MonoBehaviour
{
    public Animator animator;
    public Boolean doubleSaut = true;
    public Boolean canDoubleJump = true;
    public Boolean dashPet = false;
    public Boolean fusRohDah = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float speed = 1;
        animator.SetFloat("Speed", 0);

        if (horizontal > 0 || horizontal < 0) 
        {
            animator.SetFloat("Speed", 10);
            speed = 10;
        }

        float jump = Input.GetAxis("Jump");

        if (GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>()) && jump == 0.0f) {
            animator.SetBool("Jump", false);
            canDoubleJump = true;
        } 
        else
        {
            animator.SetBool("Jump", true);
        }


        if (jump > 0 && GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>())) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
        } 

        if (horizontal > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (doubleSaut) 
        {
            Debug.Log("Je peux double sauter");
            if (jump > 0 && !GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>()) && canDoubleJump) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
                canDoubleJump = false;
            } 
        }
        else 
        {
            Debug.Log("Je peux pas double sauter");
        }

        transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
        
    }
}
