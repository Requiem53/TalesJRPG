using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUnit : MonoBehaviour
{
    [SerializeField] private BattleHUD _target;
    [SerializeField] private Button _button;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonName;

    public BattleHUD Target { get => _target; set => _target = value; }
    public string ButtonName { get => _buttonName.text; set => _buttonName.text = value; }

    public void SetName(string name)
    {
        _button = this.GetComponent<Button>();
        _buttonName = _button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        _buttonName.text = name;
    }
}
