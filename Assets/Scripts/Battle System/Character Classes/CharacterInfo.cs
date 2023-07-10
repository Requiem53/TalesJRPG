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

    public string Name { get => _name; set => _name = value; }
    public CharacterClass CharClass { get => _charClass; set => _charClass = value; }
    public int Level { get => _level; set => _level = value; }
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int CurrentMana { get => _currentMana; set => _currentMana = value; }

    private void Start()
    {
        CharClass = this.GetComponent<CharacterClass>();
    }

}
