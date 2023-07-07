using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStats : MonoBehaviour
{
    [SerializeField] private string _name = "Generic";
    [SerializeField] private int _maxHealth = 20;
    [SerializeField] private int _health = 20;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 10f;

    public string Name { get => _name;}
    public int MaxHealth { get => _maxHealth;}
    public int Health { get => _health; set => _health = value; }
    public int Damage { get => _damage;}
    public float Speed { get => _speed;}

    public bool TakeDamage(int damage)
    {
        Health -= damage;

        if(Health <= 0){
            return true;
        }else{
            return false;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    
}
