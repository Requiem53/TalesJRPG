using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterClass : MonoBehaviour
{
    [SerializeField] protected Stats Stats;

    [SerializeField] private string _class;
    [SerializeField] private int _strength;
    [SerializeField] private int _resilience;
    [SerializeField] private int _agility;
    [SerializeField] private int _wisdom;
    [SerializeField] private int _luck;

    //FOR TWEAKING
    [SerializeField] private float _strengthMult = 1.12f;
    [SerializeField] private float _resilienceMult = 1.12f;
    [SerializeField] private float _agilityMult = 1.12f;
    [SerializeField] private float _wisdomMult = 1.12f;
    [SerializeField] private float _luckMult = 1.12f;

    public string Class { get => _class; set => _class = value; }
    public int Strength { get => _strength; set => _strength = value; }
    public int Resilience { get => _resilience; set => _resilience = value; }
    public int Agility { get => _agility; set => _agility = value; }
    public int Wisdom { get => _wisdom; set => _wisdom = value; }
    public int Luck { get => _luck; set => _luck = value; }

    void Start()
    {
        Stats = this.GetComponent<Stats>();
    }

    public virtual void StatsSetter()
    {
        Stats.SetMaxHealth = (int)((float)Resilience * _resilienceMult);
        Stats.SetMaxMana = (int)((float)Wisdom * _wisdomMult);
        Stats.SetDamage = (int)((float)Strength * _strengthMult);
        Stats.SetSpeed = (int)((float)Agility * _agilityMult);
    }
    public abstract void InitializeClass();

    public abstract void LevelUp();
}
