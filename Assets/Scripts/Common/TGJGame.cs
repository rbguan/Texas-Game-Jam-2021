using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGJGame : Singleton<TGJGame>
{
    protected override void Awake()
    {
        base.Awake();
        PrefabLoader.LoadAllAtPath();
    }
    
    private void Start()
    {
        LevelGenerator.Current.GenerateLevel();
    }
}
