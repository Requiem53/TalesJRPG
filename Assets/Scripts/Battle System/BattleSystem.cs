using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : BattleStateMachine
{
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;

    [SerializeField] private Stats playerStats;
    [SerializeField] private Stats enemyStats;

    //Maybe combiine both?
    [SerializeField] private BattleHUD playerHUD;
    [SerializeField] private BattleHUD enemyHUD;

    public TMPro.TextMeshProUGUI DialogueText => dialogueText;

    public Stats PlayerStats => playerStats;
    public Stats EnemyStats => enemyStats;

    public BattleHUD PlayerHUD => playerHUD;
    public BattleHUD EnemyHUD => enemyHUD;


    private void Start()
    {
        SetState(new Begin(this));
    }

    public void OnAttackButton()
    {
        StartCoroutine(BattleState.Attack());
    }

    public void OnHealButton()
    {
        StartCoroutine(BattleState.Heal());
    }

    public void SetDialogue(string dialogue)
    {
        DialogueText.text = dialogue;
    }
}
