using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    private Inventory shopInventory;
    [SerializeField] UI_Inventory uiInventory;
    [SerializeField] GameObject uiShopInventory;
    [SerializeField] List<Item> shopItems = new List<Item>();
    [SerializeField] PlayerController pla;

    private void Start()
    {
        shopInventory = new Inventory();

        foreach(Item item in shopItems)
        {
            shopInventory.AddItem(item);
        }
    }


    public void OpenShop()
    {
        if(this.gameObject.name.Equals("NPC Maria"))
        {
            pla.otherOpened = true;
            uiInventory.SetShop(shopInventory);
            uiShopInventory.SetActive(true);
        }
        
    }

    public void CloseShop()
    {
        pla.otherOpened = false;
        uiShopInventory.SetActive(false);
    }
}
