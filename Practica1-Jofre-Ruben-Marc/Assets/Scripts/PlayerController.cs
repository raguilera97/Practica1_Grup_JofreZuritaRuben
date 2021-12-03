using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    private float velocity = 2f;
    private float xInput, yInput;
    private Enums.Direction dir = Enums.Direction.South;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        CheckInput();
        ApplyMovement();
        UpdateAnimation();
    }


    private void UpdateAnimation()
    {
        anim.SetFloat("X", xInput);
        anim.SetFloat("Y", yInput);

        anim.SetBool("isRunning", Math.Abs(xInput) >= 0.1f || Math.Abs(yInput) >= 0.1f);

        if(CheckDirection() == Enums.Direction.West)
        {
            anim.SetFloat("LookX", -1.0f);
            anim.SetFloat("LookY", 0.0f);
        }
        else if(CheckDirection() == Enums.Direction.East)
        {
            anim.SetFloat("LookX", 1.0f);
            anim.SetFloat("LookY", 0.0f);
        }
        else if (CheckDirection() == Enums.Direction.South)
        {
            anim.SetFloat("LookX", 0.0f);
            anim.SetFloat("LookY", -1.0f);
        }
        else if (CheckDirection() == Enums.Direction.North)
        {
            anim.SetFloat("LookX", 0.0f);
            anim.SetFloat("LookY", 1.0f);
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(xInput * velocity, yInput*velocity);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }


    public Enums.Direction CheckDirection()
    {
        if(yInput == -1)
        {
            dir = Enums.Direction.South;
        }
        else if (yInput == 1)
        {
            dir = Enums.Direction.North;
        }
        else if (xInput == -1)
        {
            dir = Enums.Direction.West;
        }
        else if (xInput == 1)
        {
            dir = Enums.Direction.East;
        }

        return dir;
    }

}
