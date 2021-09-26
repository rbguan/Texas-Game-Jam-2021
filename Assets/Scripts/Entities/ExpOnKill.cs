using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOnKill : EntityPart
{
    public int exp;

    private void OnDestroy()
    {
        if (PlayerStats.Current)
            PlayerStats.Current.Exp += exp;
        Debug.Log("Player EXP: " + PlayerStats.Current.Exp);
    }
}
