using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreenResetter : MonoBehaviour
{
    private void Awake()
    {
        if (!TGJGameManager.Current.hasVisitedUpgrade)
        {
            TGJGameManager.Current.hasVisitedUpgrade = true;
            
        }
    }
}
