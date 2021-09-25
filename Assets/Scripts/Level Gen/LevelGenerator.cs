using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : Singleton<LevelGenerator>
{   
    [Header("Level Parameters")]
    [SerializeField] private Level currentLevel;

    [Header("Section Prefabs")]
    [SerializeField] private GameObject startingSectionPrefab;
    [SerializeField] private List<GameObject> sectionPrefabs = new List<GameObject>();

    public static Level CurrentLevel => Current.currentLevel;

    public static List<GameObject> SectionPrefabs => Current.sectionPrefabs;

    protected override void Awake()
    {
        base.Awake();
    }

    public void GenerateLevel()
    {
        int x = currentLevel.grid.width / 2;
        int y = currentLevel.grid.height / 2;
        for (int i = 0; i <= CurrentLevel.maxSections; i++)
        {
            Vector2Int position = new Vector2Int(x, y);
            if (SectionPlacementHandler.TryPlaceSection(startingSectionPrefab, position, out Section currentSection))
                Debug.Log("Successfully placed section " + i + "@" + position);
            else
            {
                Debug.LogError("Could not place section " + i + "@" + position);
                i--;
            }
            int xStep = Random.Range(-1, 2);
            x += xStep;
            y += xStep == 0 ? Choose.Random(-1, 1) : 0;
        }
        Debug.Log("Level generated.");
    }
}
