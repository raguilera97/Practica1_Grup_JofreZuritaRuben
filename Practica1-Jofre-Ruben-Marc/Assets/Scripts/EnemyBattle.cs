using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle: MonoBehaviour
{

	public string nameE;
	public int level;

	public int damage;
	public int maxHP;
	public int currentHP;

	public bool TakeDamage(int damg)
	{
		currentHP -= damg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}
}
