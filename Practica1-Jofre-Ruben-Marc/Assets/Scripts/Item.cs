using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public enum ItemType
    {
        cheese,
        barbarianHelmet,
        clippedShotgun,
        noFingerMittens,
        coins,
    }

    public ItemType itemType;
    public int amount;
    public int id;
    public float damage = 0;
    public float atackVelocity = 0;
    public float recuperationHealth = 0;
    public float armor = 0;

    public void setObjectStats()
    {
        switch (itemType)
        {
            default:
            case ItemType.cheese:
                recuperationHealth = 20f;
                break;
            case ItemType.coins:
                break;
            case ItemType.barbarianHelmet:
                armor = 15f;
                break;
            case ItemType.clippedShotgun:
                atackVelocity = 0.25f;
                damage = 50f;
                break;
            case ItemType.noFingerMittens:
                armor = 3f;
                break;
        }
    }
    public void setID(Inventory inventory)
    {
        List<Item> items;
        int nmbrItms;

        items = inventory.GetItemList();
        nmbrItms = items.Count;

        this.id = nmbrItms;
    }

    public int getID()
    {
        return this.id;
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.barbarianHelmet: return ItemAssets.Instance.barbarianHelmet;
            case ItemType.cheese: return ItemAssets.Instance.chesse;
            case ItemType.clippedShotgun: return ItemAssets.Instance.clippedShotgun;
            case ItemType.coins: return ItemAssets.Instance.coins;
            case ItemType.noFingerMittens: return ItemAssets.Instance.noFingerMittens;

        }
    }

    public string GetName()
    {
        
        switch (itemType)
        {
            default:
            case ItemType.barbarianHelmet: return ItemAssets.Instance.namebarbarianHelmet;
            case ItemType.cheese: return ItemAssets.Instance.nameCheese;
            case ItemType.clippedShotgun: return ItemAssets.Instance.nameclippedShotgun;
            case ItemType.coins: return ItemAssets.Instance.namecoins;
            case ItemType.noFingerMittens: return ItemAssets.Instance.namenoFingerMittens;

        }
    }

    public bool IsStackeable()
    {
        switch (itemType)
        {
            default:
            case ItemType.coins:
            case ItemType.cheese:
                return true;
            case ItemType.barbarianHelmet:
            case ItemType.clippedShotgun:
            case ItemType.noFingerMittens:
                return false;
        }
    }
}
