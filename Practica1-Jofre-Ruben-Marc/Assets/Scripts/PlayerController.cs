using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    
    private float velocity = 4f;
    private float xInput, yInput;
    private Enums.Direction dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        CheckInput();
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(xInput * velocity,yInput*velocity);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }


    public Enums.Direction CheckDirection()
    {
        if(yInput == 1)
        {
            dir = Enums.Direction.North;
        }
        else if (yInput == -1)
        {
            dir = Enums.Direction.South;
        }
        else if (xInput == 1)
        {
            dir = Enums.Direction.West;
        }
        else if (xInput == -1)
        {
            dir = Enums.Direction.East;
        }

        return dir;
    }

}
