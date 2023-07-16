using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : BattleStateMachine
{
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;

    public TMPro.TextMeshProUGUI DialogueText => dialogueText;

    //Maybe combiine both?
    [SerializeField] private List<BattleHUD> playerHUDs;
    [SerializeField] private List<BattleHUD> enemyHUDs;

    public List<BattleHUD> Player => playerHUDs;
    public List<BattleHUD> Enemy => enemyHUDs;

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
