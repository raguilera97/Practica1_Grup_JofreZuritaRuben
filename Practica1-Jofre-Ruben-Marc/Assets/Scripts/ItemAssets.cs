using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite chesse;
    public Sprite barbarianHelmet;
    public Sprite clippedShotgun;
    public Sprite noFingerMittens;
    public Sprite coins;

    public string nameCheese = "Cheese";
    public string namebarbarianHelmet = "Barbarian Helmet";
    public string nameclippedShotgun = "Clipped Shotgun";
    public string namenoFingerMittens = "Finger Mittens";
    public string namecoins = "Coins";

}
