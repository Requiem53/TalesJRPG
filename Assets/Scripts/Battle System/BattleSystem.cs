using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : BattleStateMachine
{
    [SerializeField] private BattleTurnOrder battleTurnOrder;
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;

    public TMPro.TextMeshProUGUI DialogueText => dialogueText;

    [SerializeField] private List<BattleHUD> playerHUDs;
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

    public void OnCastButton(Spells spell, BattleHUD target)
    {
        StartCoroutine(BattleState.CastSpell(spell, target));
    }

    public void OnAttackButton(BattleHUD target)
    {
        StartCoroutine(BattleState.Attack(target));
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

    public BattleTurnOrder BattleTurn{get => this.Turn;}
    public int TurnNumber{get => this.Turn.TurnNumber;}
    public BattleHUD BattlerHUD{get => this.Turn.TurnOrder[TurnNumber];}
    public Stats Battler{get => BattlerHUD.Stats;}
}
