using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUnit : MonoBehaviour
{
    [SerializeField] private Stats _target;
    [SerializeField] private Button _button;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonName;

    public Stats Target { get => _target; set => _target = value; }
    public Button Button { get => _button; set => _button = value; }

    public void ReferenceComponents()
    {
        Button = this.GetComponent<Button>();
        _buttonName = Button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }
    public void SetName(string name)
    {
        _buttonName.text = name;
    }

}
