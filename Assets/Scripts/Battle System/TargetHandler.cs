using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{
    //MAY NOT BE USEFUL AFTER ALL. REUSE FOR GENERATING BUTTONS
    [SerializeField] private BattleSystem BattleSystem;
    [SerializeField] private Button button;
    [SerializeField] private List<BattleHUD> _validAllyTargets;
    [SerializeField] private List<BattleHUD> _validEnemyTargets;
    public List<BattleHUD> ValidAllyTargets { get => _validAllyTargets; set => _validAllyTargets = value; }
    public List<BattleHUD> ValidEnemyTargets { get => _validEnemyTargets; set => _validEnemyTargets = value; }

    private void Start()
    {
        GenerateEnemyTargetButtons();
    }

    public void TargetsEnemies()
    {
    }

    public void TargetsAllies()
    {
    }

    private void GenerateEnemyTargetButtons()
    {
        for(int i = 0; i < BattleSystem.Enemy.Count; i++)
        {
            Instantiate(button, this.transform);
        }
    }

}
