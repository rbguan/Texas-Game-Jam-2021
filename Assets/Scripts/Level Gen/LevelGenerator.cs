using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{   
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
    }

    public void GenerateLevel()
    {

    }
}
