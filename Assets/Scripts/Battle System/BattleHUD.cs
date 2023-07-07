using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _nameText;
    [SerializeField] private TMPro.TextMeshProUGUI _healthText;

    public void SetHUD(BattleStats stats)
    {
        _nameText.text = stats.Name;
        _healthText.text = stats.Health + "/" + stats.MaxHealth;
    }
}
