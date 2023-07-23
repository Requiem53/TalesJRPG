using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : ScriptableObject, Actions
{
    [SerializeField] private string _name;
    [SerializeField] private int _manaCost;

    public string Name { get => _name; set => _name = value; }
    public int ManaCost { get => _manaCost; set => _manaCost = value; }

    public abstract void Start();

    public virtual void Heal(Stats target)
    {
    }

    
}
