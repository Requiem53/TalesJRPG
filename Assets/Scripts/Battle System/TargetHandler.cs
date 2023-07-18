using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{
    //MAY NOT BE USEFUL AFTER ALL. REUSE FOR GENERATING BUTTONS
    [SerializeField] private BattleSystem BattleSystem;
    [SerializeField] private TargetUnit button;

    public List<BattleHUD> ValidAllyTargets { get => BattleSystem.Player;}
    public List<BattleHUD> ValidEnemyTargets { get => BattleSystem.Enemy;}

    private void Start()
    {
        GenerateTargetButtons(ValidAllyTargets);
        GenerateTargetButtons(ValidEnemyTargets);
    }

    private void GenerateTargetButtons(List<BattleHUD> ValidTargets)
    {
        for(int i = 0; i < ValidTargets.Count; i++)
        {
            TargetUnit attackButton = Instantiate(button, this.transform);
            attackButton.gameObject.SetActive(true);
            attackButton.Target = ValidTargets[i];
            attackButton.name = ValidTargets[i].Stats.CharInfo.Name;
            attackButton.SetName(ValidTargets[i].Stats.CharInfo.Name);
        }
    }

}
