using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        addItem(new Item { itemType = Item.ItemType.barbarianHelmet, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.cheese, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.clippedShotgun, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.noFingerMittens, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.barbarianHelmet, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.coins, amount = 1 });
    }

    public void addItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
