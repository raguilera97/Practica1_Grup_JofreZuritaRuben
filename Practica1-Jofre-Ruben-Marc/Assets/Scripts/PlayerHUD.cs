using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
	public Text nameText;
	public Text levelText;
	public Slider hpSlider;

	public GameObject player;

    private void Start()
    {
		hpSlider.value = player.GetComponent<PlayerController>().currentHealth;
    }


    public void SetHUD(PlayerController unit, LevelSystem sys)
	{
		nameText.text = unit.nameP;
		levelText.text = "Lvl 0" + (sys.level + 1);
		hpSlider.maxValue = unit.maxHealth;
		hpSlider.value = unit.currentHealth;
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
	}
}
