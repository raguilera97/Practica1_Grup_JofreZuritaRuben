using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
	public Text nameText;
	public Text levelText;
	public Slider hpSlider;

	public void SetHUD(EnemyBattle unit)
	{
		nameText.text = unit.nameE;
		levelText.text = "Lvl " + unit.level;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
	}
}
