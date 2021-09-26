using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreenResetter : MonoBehaviour
{
    private void Start()
    {
        if (!TGJGameManager.Current.hasVisitedUpgrade)
        {
            TGJGameManager.Current.hasVisitedUpgrade = true;
            Upgrades.Current.ResetUpgradeGraphics();
            Debug.Log("Resetting Upgrade Graphics");
        }
        else
        {
            Upgrades.Current.InitializeUpgradeGraphics();
            Debug.Log("Initializing Upgrade Graphics");
        }
    }
}
