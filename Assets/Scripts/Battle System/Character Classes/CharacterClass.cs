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


    public string Class { get => _class; set => _class = value; }
    public int Strength { get => _strength; set => _strength = value; }
    public int Resilience { get => _resilience; set => _resilience = value; }
    public int Agility { get => _agility; set => _agility = value; }
    public int Wisdom { get => _wisdom; set => _wisdom = value; }
    public int Luck { get => _luck; set => _luck = value; }

    void Awake()
    {
        Stats = this.GetComponent<Stats>();
    }

    public virtual void StatsSetter()
    {
        Stats.SetMaxHealth = (int)((float)Resilience * StatsMultiplier.ResilienceMult);
        Stats.SetMaxMana = (int)((float)Wisdom * StatsMultiplier.WisdomMult);
        Stats.SetDamage = (int)((float)Strength * StatsMultiplier.StrengthMult);
        Stats.SetSpeed = (int)((float)Agility * StatsMultiplier.AgilityMult);
    }
    public abstract void InitializeClass();

    public abstract void LevelUp();
}
