using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private CharacterInfo _charInfo;
    [SerializeField] private List<Spells> spellList;

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxMana;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isPlayable;

    public CharacterInfo CharInfo { get => _charInfo; set => _charInfo = value; }

    public int MaxHealth { get => _maxHealth;}
    public int MaxMana { get => _maxMana;}
    public int Damage { get => _damage;}
    public float Speed { get => _speed;}
    public bool IsPlayable { get => _isPlayable;}

    public int SetMaxHealth { get => _maxHealth; set => _maxHealth = value;}
    public int SetMaxMana { get => _maxMana; set => _maxMana = value; }
    public int SetDamage { get => _damage; set => _damage = value;}
    public float SetSpeed { get => _speed; set => _speed = value;}
    
    public void CastSpell(Spells spell)
    {
        spell.Start();
    }

    public void TakeDamage(int damage)
    {
        CharInfo.CurrentHealth = Math.Max(0, CharInfo.CurrentHealth - damage);
    }

    public void Heal(int amount)
    {
        CharInfo.CurrentHealth += amount;
        if(CharInfo.CurrentHealth > MaxHealth)
        {
            CharInfo.CurrentHealth = MaxHealth;
        }
    }


    private void Awake()
    {
        InitializeStats();
    }

    private void Update()
    {
        LevelUpTest();
    }


    private void LevelUpTest()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            CharInfo.CharClass.LevelUp();
        }
    }

    private void InitializeStats()
    {
        CharInfo = this.GetComponent<CharacterInfo>();
        CharInfo.CharClass.InitializeClass();
        CharInfo.CharClass.StatsSetter();
        ValidateStats();
    }

    public void ValidateStats()
    {
        CharInfo.CurrentHealth = Math.Min(CharInfo.CurrentHealth, MaxHealth);
        CharInfo.CurrentMana = Math.Min(CharInfo.CurrentMana, MaxMana);
    }
}
