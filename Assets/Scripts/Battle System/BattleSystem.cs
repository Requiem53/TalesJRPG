    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : BattleStateMachine
{
    [SerializeField] private BattleTurnOrder battleTurnOrder;
    [SerializeField] private List<Stats> _players;
    [SerializeField] private List<Stats> _enemies;
    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;
    [SerializeField] private Transform _playerBattleStation;
    [SerializeField] private Transform _enemyBattleStation;

    public BattleTurnOrder Turn { get => battleTurnOrder; set => battleTurnOrder = value; }
    public List<Stats> Player => _players;
    public List<Stats> Enemy => _enemies;
    public TMPro.TextMeshProUGUI DialogueText => dialogueText;

    private void Start()
    {
        SummonCharacters();
        SetState(new Begin(this));
    }

    public void OnMeleeAttackButton(Stats target)
    {
        Debug.Log("Current State: " + BattleState);
        StartCoroutine(BattleState.Attack(target));
    }

    public void OnCastButton(Spells spell, Stats target)
    {
        StartCoroutine(BattleState.CastSpell(spell, target));
    }

    public void OnAttackButton(Stats target)
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
    public Stats Battler{get => this.Turn.TurnOrder[TurnNumber];}
}
