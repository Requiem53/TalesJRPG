using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurnOrder : MonoBehaviour
{
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private List<Stats> _turnOrder;

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
        _turnOrder.Sort(new SpeedCompare());
    }

    private void CombineList()
    {
        for(int i = 0; i < _battleSystem.Player.Count; i++)
        {
            _turnOrder.Add(_battleSystem.Player[i].Stats);
        }
        for(int i = 0; i < _battleSystem.Enemy.Count; i++)
        {
            _turnOrder.Add(_battleSystem.Enemy[i].Stats);
        }
    }
}
