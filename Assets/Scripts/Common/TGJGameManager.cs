using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGJGameManager : Singleton<TGJGameManager>
{
    private bool hasVisitedUpgrade;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
