using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateBattle {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : BattleStateMachine
{
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;

    [SerializeField] private BattleStats playerStats;
    [SerializeField] private BattleStats enemyStats;

    [SerializeField] private BattleHUD playerHUD;
    [SerializeField] private BattleHUD enemyHUD;

    [SerializeField] private StateBattle state;

    private void Start()
    {
        state = StateBattle.START;
        StartCoroutine(SetUpBattle());
    }

    private IEnumerator SetUpBattle()
    {
        dialogueText.text = "A wild " + enemyStats.Name + " approaches....";

        playerHUD.SetHUD(playerStats);
        enemyHUD.SetHUD(enemyStats);

        yield return new WaitForSeconds(1f);

        state = StateBattle.PLAYERTURN;
        PlayerTurn();

    }

    private void PlayerTurn()
    {
        dialogueText.text = "Choose an action.";
    }

    IEnumerator PlayerHeal()
    {
        playerStats.Heal(10);
        dialogueText.text = playerStats.Name + " healed themselves!";

        playerHUD.SetHUD(playerStats);
        yield return new WaitForSeconds(1f);

        state = StateBattle.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyStats.TakeDamage(playerStats.Damage);

        dialogueText.text = playerStats.Name + " attacked " + enemyStats.Name + "!";

        enemyHUD.SetHUD(enemyStats);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = StateBattle.WON;
            EndBattle();
        }else
        {
            state = StateBattle.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text =  enemyStats.Name + " attacks you!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerStats.TakeDamage(enemyStats.Damage);

        playerHUD.SetHUD(playerStats);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = StateBattle.LOST;
            EndBattle();
        }else
        {
            state = StateBattle.PLAYERTURN;
            PlayerTurn();
        }

    }

    private void EndBattle()
    {
        if(state == StateBattle.WON)
        {
            dialogueText.text = "You win!";
        } else if(state == StateBattle.LOST)
        {
            dialogueText.text = "You lost..";
        }
    }

    public void OnAttackButton()
    {
        if(state != StateBattle.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if(state != StateBattle.PLAYERTURN) return;

        StartCoroutine(PlayerHeal());
    }
}
