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

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController pla = other.gameObject.GetComponent<PlayerController>();
        if (pla)
        {
            OpenShop();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        PlayerController pla = other.gameObject.GetComponent<PlayerController>();
        if (pla)
        {
            CloseShop();
        }
    }

    public void OpenShop()
    {
        pla.otherOpened = true;
        uiInventory.SetShop(shopInventory);
        uiShopInventory.SetActive(true);
    }

    public void CloseShop()
    {
        pla.otherOpened = false;
        uiShopInventory.SetActive(false);
    }
}
