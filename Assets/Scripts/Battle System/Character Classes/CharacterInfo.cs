using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private CharacterClass _charClass;
    [SerializeField] private int _level;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _currentMana;

    public event Action OnStatsChange;

    private void Awake()
    {
        CharClass = this.GetComponent<CharacterClass>();
    }

    public string Name 
    { 
        get{return _name;}
        set
        {
            _name = value;
            OnStatsChange();
        }
    }
    public CharacterClass CharClass
    { 
        get{return _charClass;}
        set
        {
             _charClass = value;
            OnStatsChange?.Invoke();
        }

    }
    public int Level 
    { 
        get{return _level;}
        set
        {
             _level = value;
            OnStatsChange?.Invoke();
        }
    }

    public int CurrentHealth 
    { 
        get{return _currentHealth;}
        set
        {
             _currentHealth = value;
            OnStatsChange?.Invoke();
        }
    }

    public int CurrentMana
    { 
        get{return _currentMana;}
        set
        {
             _currentMana = value;
            OnStatsChange?.Invoke();
        }
    }
}
