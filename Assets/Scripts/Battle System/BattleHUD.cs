using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _nameText;
    [SerializeField] private TMPro.TextMeshProUGUI _healthText;

    public void SetHUD(Stats stats)
    {
        _nameText.text = stats.CharInfo.Name;
        _healthText.text = stats.CharInfo.CurrentHealth + "/" + stats.MaxHealth;
    }
}
