using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{
    //MAY NOT BE USEFUL AFTER ALL. REUSE FOR GENERATING BUTTONS
    [SerializeField] private BattleSystem BattleSystem;
    [SerializeField] private TargetUnit button;

    [SerializeField] private bool forAllies;

    public List<BattleHUD> ValidAllyTargets { get => BattleSystem.Player;}
    public List<BattleHUD> ValidEnemyTargets { get => BattleSystem.Enemy;}

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

    private void GenerateTargetButtons(List<BattleHUD> ValidTargets)
    {
        for(int i = 0; i < ValidTargets.Count; i++)
        {
            GenerateButton(ValidTargets[i]);
        }
    }

    private void GenerateButton(BattleHUD validTarget)
    {
        TargetUnit attackButton = Instantiate(button, this.transform);
        attackButton.gameObject.SetActive(true);
        attackButton.Target = validTarget;
        attackButton.name = validTarget.Stats.CharInfo.Name;
        attackButton.ReferenceComponents();
        attackButton.SetName(validTarget.Stats.CharInfo.Name);
        attackButton.Button.onClick.AddListener(() => BattleSystem.OnAttackButton(attackButton.Target));
    }

}
