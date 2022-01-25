using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
    
    [SerializeField] UI_Inventory uiInventory;
    [SerializeField] GameObject uiChestInventory;
    [SerializeField] List<Item> chestitems = new List<Item>();
    [SerializeField] PlayerController pla;

    private bool chestOpen = false;
    private Inventory chestInventory;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        chestInventory = new Inventory();
        foreach(Item item in chestitems)
        {
            chestInventory.AddItem(item);
        }
    }
    public void Interact()
    {
        anim.SetTrigger("Open");
        if (chestOpen)
        {
            pla.otherOpened = false;
            chestOpen = false;
            uiChestInventory.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void OpenChest()
    {
        pla.otherOpened = true;
        if (!chestOpen)
        {
            chestOpen = true;
            uiInventory.SetInventory(chestInventory);
            uiChestInventory.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    
    
}
