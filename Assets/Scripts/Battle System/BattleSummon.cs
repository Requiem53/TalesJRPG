using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSummon : MonoBehaviour
{
    [SerializeField] private List<Stats> _playerCharacters;
    [SerializeField] private List<Stats> _enemyCharacters;

    [SerializeField] private Transform _playerBattleStation;
    [SerializeField] private Transform _enemyBattleStation;

    private void Start()
    {
        InitializeBattlers();
    }

    private void InitializeBattlers()
    {
        SummonCharacters(_playerCharacters, _playerBattleStation);
        SummonCharacters(_enemyCharacters, _enemyBattleStation);
    }

    private static void SummonCharacters(List<Stats> characters, Transform battleStation)
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if(characters[i] != null)
            {
                characters[i].gameObject.SetActive(true); 
                characters[i].transform.SetParent(battleStation, true);
            }
            
        } 
    }


}
