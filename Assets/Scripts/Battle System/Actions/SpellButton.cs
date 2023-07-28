using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    [SerializeField] private Spells spell;
    private Button _button;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonName;

    public Spells Spell { get => spell; set => spell = value; }

    private void ReferenceComponents()
    {
        _button = this.GetComponent<Button>();
        _buttonName = _button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    public void GenerateSpellButton(Spells spell)
    {
        ReferenceComponents();
        _button.name = spell.Name;
        _buttonName.text = spell.Name;
        Spell = spell;

    }


}
