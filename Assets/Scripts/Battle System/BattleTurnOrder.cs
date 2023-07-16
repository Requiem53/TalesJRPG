using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurnOrder : MonoBehaviour
{
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private List<BattleHUD> _turnOrder;
    [SerializeField] private int _turnNumber;

    public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
    public List<BattleHUD> TurnOrder { get => _turnOrder; set => _turnOrder = value; }
    public BattleSystem BattleSystem { get => _battleSystem; set => _battleSystem = value; }

    private void Start()
    {
        CombineList();
        SortSpeed();
    }
  
    private void Update()
    {
        //Speed Test
        if(Input.GetKeyDown(KeyCode.L))
        {
            SortSpeed();
        }
    }
    public void SortSpeed()
    {
        TurnOrder.Sort(new SpeedCompare());
    }

    private void CombineList()
    {
        for(int i = 0; i < BattleSystem.Player.Count; i++)
        {
            TurnOrder.Add(BattleSystem.Player[i]);
        }
        for(int i = 0; i < BattleSystem.Enemy.Count; i++)
        {
            TurnOrder.Add(BattleSystem.Enemy[i]);
        }
    }

}
