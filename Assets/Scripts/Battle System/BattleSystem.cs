using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : BattleStateMachine
{
    [SerializeReference] private BattleTurnOrder battleTurnOrder;
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;

    public TMPro.TextMeshProUGUI DialogueText => dialogueText;

    [SerializeReference] private List<BattleHUD> playerHUDs;
    [SerializeField] private List<BattleHUD> enemyHUDs;

    public List<BattleHUD> Player => playerHUDs;
    public List<BattleHUD> Enemy => enemyHUDs;

    public BattleTurnOrder Turn { get => battleTurnOrder; set => battleTurnOrder = value; }

    [SerializeField] private Transform _playerBattleStation;
    [SerializeField] private Transform _enemyBattleStation;


    private void Start()
    {
        SummonCharacters();
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

    private void SummonCharacters()
    {
        BattleSummon.SummonCharacters(Player, _playerBattleStation);
        BattleSummon.SummonCharacters(Enemy, _enemyBattleStation);
    }

}
