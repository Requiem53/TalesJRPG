using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonComponents : MonoBehaviour
{
    [SerializeField] private List<GameObject> _options;
    [SerializeField] private GameObject _allies;
    [SerializeField] private GameObject _enemies;
    [SerializeField] private GameObject _spells;
    

    public void DisplayAllies()
    {
        _allies.SetActive(true);
        _enemies.SetActive(false);
        _spells.SetActive(false);
    }

    public void DisplayEnemies()
    {
        _enemies.SetActive(true);
        _allies.SetActive(false);
        _spells.SetActive(false);
    }

    public void DisplaySpells()
    {
        _spells.SetActive(true);
        _allies.SetActive(false);
        _enemies.SetActive(false);   
    }
    private void Display()
    {
        
    }
}
