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

	PlayerBattle playerUnit;
	EnemyBattle enemyUnit;

	public Text combatText;

	public PlayerHUD playerHUD;
	public EnemyHUD enemyHUD;

	public BattleState state;

	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}
	
	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattlePos);
		playerUnit = playerGO.GetComponent<PlayerBattle>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePos);
		enemyUnit = enemyGO.GetComponent<EnemyBattle>(); 

		combatText.text = " Fight starts!! " ;

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	void PlayerTurn()
	{
		combatText.text = "What are you going to do: ";
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		combatText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

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
		combatText.text = enemyUnit.nameE + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

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
		}
		else if (state == BattleState.LOST)
		{
			combatText.text = "You were defeated.";
		}
	}
	
}
