using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSummon
{
    public static void SummonCharacters(List<Stats> characters, Transform battleStation)
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if(characters[i] != null)
            {
                characters[i].gameObject.SetActive(true); 
                characters[i].transform.SetParent(battleStation, true);
            }
            
        } 
    }


}
