using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        anim.SetTrigger("Open");
    }

    
    
}
