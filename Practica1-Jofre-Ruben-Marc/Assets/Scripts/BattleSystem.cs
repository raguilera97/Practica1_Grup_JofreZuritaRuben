using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattlePos;
	public Transform enemyBattlePos;

	PlayerController playerUnit;
	EnemyBattle enemyUnit;
	LevelSystem lvl;

	public Text combatText;

	public PlayerHUD playerHUD;
	public EnemyHUD enemyHUD;
	public GameObject battleHUD;
	public GameObject player;
	public GameObject attackButton;
	public GameObject itemButton;

	public bool inBattle = false;
	

	public BattleState state;

	

	public void battleStarts()
    {
		inBattle = true;
		player.SetActive(false);
		//playerHUD.hpSlider.value = player.GetComponent<PlayerController>().currentHealth;
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}
	
	IEnumerator SetupBattle()
	{
		battleHUD.SetActive(true);

		GameObject playerGO = Instantiate(playerPrefab, playerBattlePos);
		playerUnit = playerGO.GetComponent<PlayerController>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePos);
		enemyUnit = enemyGO.GetComponent<EnemyBattle>();

		combatText.text = " Fight starts!! " ;

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		if(playerUnit.atackVelocity > enemyUnit.speed)
        {
			state = BattleState.PLAYERTURN;
			PlayerTurn();
        }
        else
        {
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());

		}
		
	}

	void PlayerTurn()
	{
		combatText.text = "What are you going to do? ";

		attackButton.SetActive(true);
		itemButton.SetActive(true);
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	IEnumerator PlayerAttack()
	{
		attackButton.SetActive(false);
		itemButton.SetActive(false);

		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		
		if(playerUnit.isCrit == true)
        {
			combatText.text = enemyUnit.nameE + " recieves a critical hit!";

			yield return new WaitForSeconds(2f);
        }
        else
        {
			combatText.text = "You attacked succesfully!";

			yield return new WaitForSeconds(2f);
		}

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
			
			
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}
	
	IEnumerator EnemyTurn()
	{

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHealth);

		yield return new WaitForSeconds(1f);

		if (enemyUnit.isCrit == true)
		{
			combatText.text =  "You recieved a critical hit!";

			yield return new WaitForSeconds(2f);
        }
        else if(enemyUnit.isCrit == false)
        {
			combatText.text = enemyUnit.nameE + " attacks!";

			yield return new WaitForSeconds(1f);
		}

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
			
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			combatText.text = "You won the battle!";
			//lvl.AddExperience(enemyUnit.amountXP);
			 
			foreach(Item item in enemyUnit.drops.GetItemList())
            {
				player.GetComponent<PlayerController>().inventory.AddItem(item);
            }

		}
		else if (state == BattleState.LOST)
		{
			combatText.text = "You were defeated.";
		}

		Destroy(playerUnit.gameObject);
		Destroy(enemyUnit.gameObject);
		battleHUD.SetActive(false);
		player.SetActive(true);
		inBattle = false;
	}
}
