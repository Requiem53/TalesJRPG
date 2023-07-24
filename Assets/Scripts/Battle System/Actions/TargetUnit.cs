using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUnit : MonoBehaviour
{
    [SerializeField] private Stats _target;
    [SerializeField] private Button _button;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonName;
    [SerializeField] private BattleSelect selection;

    //What action the Target will receive
    [SerializeField] private Actions _action;

    public Stats Target { get => _target; set => _target = value; }
    public Button Button { get => _button; set => _button = value; }
    public BattleSelect Selection { get => selection; set => selection = value; }

    private void OnEnable()
    {
        ActionHandler.OnActionDecide += SetAction;
    }

    private void OnDisable()
    {
        ActionHandler.OnActionDecide -= SetAction;
    }

    public void ReferenceComponents()
    {
        Button = this.GetComponent<Button>();
        _buttonName = Button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }
    public void SetName(string name)
    {
        _buttonName.text = name;
    }

    public void SetAction(Actions action)
    {
        _action = action;
    }

    public void ExecuteAction()
    {
        _action.StartTarget(_target);
    }


}
