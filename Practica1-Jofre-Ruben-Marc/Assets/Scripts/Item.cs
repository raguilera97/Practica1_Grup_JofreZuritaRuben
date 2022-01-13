using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
