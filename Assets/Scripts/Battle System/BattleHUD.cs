using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _nameText;
    [SerializeField] private TMPro.TextMeshProUGUI _healthText;

    [SerializeField] private Stats stats;

    public Stats Stats { get => stats; set => stats = value; }

    public void SetHUD()
    {
        _nameText.text = Stats.CharInfo.Name;
        _healthText.text = Stats.CharInfo.CurrentHealth + "/" + Stats.MaxHealth;
    }

}


