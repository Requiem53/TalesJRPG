using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUpdate : MonoBehaviour
{
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private List<SpellButton> spells;
    [SerializeField] private Transform spellList;
    [SerializeField] private SpellButton button;

    private List<Spells> battlerSpells{get => battleSystem.Battler.SpellList;}

    private void OnEnable()
    {
        Turn.OnStartTurn += SpellUpdate;
        ActionSubMenu.OnTargetsOn += EnableSpellButtons;
        Turn.OnStartTurn += ItemUpdate;
    }

    private void OnDisable()
    {
        Turn.OnStartTurn -= SpellUpdate;
        ActionSubMenu.OnTargetsOn -= EnableSpellButtons;
        Turn.OnStartTurn -= ItemUpdate;
    }

    private void SpellUpdate()
    {
        for(int i = 0; i < battlerSpells.Count; i++)
        {
            SpellButton spellButton = Instantiate(button, spellList);
            spellButton.GenerateSpellButton(battlerSpells[i]);
            spells.Add(spellButton);
        }
    }

    private void ItemUpdate()
    {
        
    }
    
    private void EnableSpellButtons(BattleSelect selection)
    {
        if(selection == BattleSelect.Spells)
        {
            for(int i = 0; i < spells.Count; i++)
            {
                spells[i].gameObject.SetActive(true);
            }
            
        }
        else
        {
            for(int i = 0; i < spells.Count; i++)
            {
                spells[i].gameObject.SetActive(false);
            }
        }
    }
}
