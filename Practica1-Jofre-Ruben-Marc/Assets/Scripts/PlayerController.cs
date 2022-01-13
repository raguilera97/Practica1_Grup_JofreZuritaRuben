using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] UI_Inventory uiInventory;
    Rigidbody2D rb;
    Animator anim;
    new Collider2D collider;

    [SerializeField] float velocity = 2f;
    [SerializeField] LayerMask interactableObject;
    [SerializeField] GameObject pressE;

    private Inventory inventory;
    private float xInput, yInput;
    private Enums.Direction dir = Enums.Direction.South;
    



    void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        CheckInput();
        ApplyMovement();
        UpdateAnimation();
        CheckInteract();
    }


    private void UpdateAnimation()
    {
        anim.SetFloat("X", xInput);
        anim.SetFloat("Y", yInput);

        anim.SetBool("isRunning", Math.Abs(xInput) >= 0.1f || Math.Abs(yInput) >= 0.1f);

        if (CheckDirection() == Enums.Direction.West)
        {
            anim.SetFloat("LookX", -1.0f);
            anim.SetFloat("LookY", 0.0f);
        }
        else if (CheckDirection() == Enums.Direction.East)
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
        rb.velocity = new Vector2(xInput * velocity, yInput * velocity);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector3 faceDir = new Vector2(anim.GetFloat("LookX"), anim.GetFloat("LookY"));

        Vector2 interactPos = transform.position + faceDir;

        Debug.DrawLine(transform.position, interactPos, Color.cyan, 0.5f);

        Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableObject);




        if (collider != null)
        {
            collider.GetComponent<Interactable>().Interact();
        }
    }

    private void CheckInteract()
    {
        collider = Physics2D.OverlapCircle(transform.position, 0.5f, interactableObject);

        if (collider)
        {
            pressE.SetActive(true);
        }
        else
        {
            pressE.SetActive(false);
        }
    }

    public Enums.Direction CheckDirection()
    {
        if (yInput == -1)
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
