using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOnKill : EntityPart
{
    public int exp;

    private void OnDestroy()
    {
        PlayerStats.Current.Exp += exp;
    }
}
