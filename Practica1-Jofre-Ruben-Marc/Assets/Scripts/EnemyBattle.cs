using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle: MonoBehaviour
{

	public string nameE;
	public int level;
	public int defense;
	public int speed = 10;
	public int crit = 1;
	public bool isCrit = false;
	public int amountXP;

	public int damage;
	public int maxHP;
	public int currentHP;

	public Inventory drops = new Inventory();
	public int goldAmount;

    private void Start()
    {
		goldAmount = Random.Range(2, 1000);
		
		drops.AddItem(new Item { itemType = Item.ItemType.coins, amount = goldAmount});
    }

    public bool TakeDamage(int damg)
	{
		if (Random.value * 100 <= 5)
		{
			crit = 2;
			isCrit = true;
		}

		currentHP = currentHP - ((damg * crit) - defense);
		
				
		if (currentHP <= 0)
        {
			return true;
        }
        else
        {
			return false;
        }
	}
}
