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
    [SerializeField] private List<Button> _validTargets;

    public List<Stats> ValidAllyTargets { get => BattleSystem.Player;}
    public List<Stats> ValidEnemyTargets { get => BattleSystem.Enemy;}
    public List<Button> ValidTargets { get => _validTargets; set => _validTargets = value; }

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
            GenerateButton(ValidTargets[i]);
        }
    }

    private void GenerateButton(Stats validTarget)
    {
        TargetUnit actionInput = Instantiate(button, this.transform);
        actionInput.gameObject.SetActive(true);
        actionInput.Target = validTarget;
        actionInput.name = validTarget.CharInfo.Name;
        actionInput.ReferenceComponents();
        actionInput.SetName(validTarget.CharInfo.Name);

        ValidTargets.Add(actionInput.Button);
        //Change so it depends on what type of listener its supposed to have?
        // attackButton.Button.onClick.AddListener(() => BattleSystem.OnAttackButton(attackButton.Target));
    }

}
