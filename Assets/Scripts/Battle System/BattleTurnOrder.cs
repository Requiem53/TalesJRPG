using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurnOrder : MonoBehaviour
{
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private List<Stats> _turnOrder;
    [SerializeField] private int _turnNumber;

    public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
    public List<Stats> TurnOrder { get => _turnOrder; set => _turnOrder = value; }

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
    private void SortSpeed()
    {
        TurnOrder.Sort(new SpeedCompare());
    }

    private void CombineList()
    {
        for(int i = 0; i < _battleSystem.Player.Count; i++)
        {
            TurnOrder.Add(_battleSystem.Player[i].Stats);
        }
        for(int i = 0; i < _battleSystem.Enemy.Count; i++)
        {
            TurnOrder.Add(_battleSystem.Enemy[i].Stats);
        }
    }
}
