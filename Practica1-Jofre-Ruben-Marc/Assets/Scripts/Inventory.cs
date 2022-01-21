using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{


    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.IsStackeable())
        {
            bool itemAlredyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlredyInInventory = true;
                }
            }
            if (!itemAlredyInInventory)
            {
                itemList.Add(item);
                item.setID(this);
                item.setObjectStats();
            }
        }
        else
        {
            itemList.Add(item);
            item.setID(this);
            item.setObjectStats();
        }
        
    }

    public void RemoveItem(Item item)
    {
       if (item.IsStackeable()){
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(item);
            }
        }
        else
        {
            itemList.Remove(item);
        }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
