using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] private BattleSystem BattleSystem;
    [SerializeField] private TargetUnit button;

    [SerializeField] private bool forAllies;
    [SerializeField] private List<TargetUnit> _validTargets;

    public List<Stats> ValidAllyTargets { get => BattleSystem.Player;}
    public List<Stats> ValidEnemyTargets { get => BattleSystem.Enemy;}
    public List<TargetUnit> ValidTargets { get => _validTargets; set => _validTargets = value; }

    private void Start()
    {
        if(forAllies)
        {
            GenerateTargetButtons(ValidAllyTargets);
        }
        else
        {
            GenerateTargetButtons(ValidEnemyTargets);
        }
    }

    private void GenerateTargetButtons(List<Stats> ValidTargets)
    {
        for(int i = 0; i < ValidTargets.Count; i++)
        {
            GenerateTargetUnitButton(ValidTargets[i]);
        }
    }

    private void GenerateTargetUnitButton(Stats validTarget)
    {
        TargetUnit actionInput = Instantiate(button, this.transform);
        actionInput.gameObject.SetActive(false);
        actionInput.Target = validTarget;
        actionInput.name = validTarget.CharInfo.Name;
        actionInput.ReferenceComponents();
        actionInput.SetName(validTarget.CharInfo.Name);
        actionInput.Button.onClick.AddListener(actionInput.ExecuteAction);
        if(forAllies)
        {
            actionInput.Selection = BattleSelect.Allies;
        }
        else
        {
            actionInput.Selection = BattleSelect.Enemies;
        }
        ValidTargets.Add(actionInput);
        //Change so it depends on what type of listener its supposed to have?
        // attackButton.Button.onClick.AddListener(() => BattleSystem.OnAttackButton(attackButton.Target));
    }

    private void OnEnable()
    {
        ActionSubMenu.OnTargetsOn += EnableButton;
    }

    private void OnDisable()
    {
        ActionSubMenu.OnTargetsOn -= EnableButton;   
    }

    private void EnableButton(BattleSelect selection)
    {
        for(int i = 0; i < ValidTargets.Count; i++)
        {
            if(ValidTargets[i].Selection == selection)
            {
                ValidTargets[i].gameObject.SetActive(true);
            }
            else
            {
                ValidTargets[i].gameObject.SetActive(false);    
            }
        }
    }

}
