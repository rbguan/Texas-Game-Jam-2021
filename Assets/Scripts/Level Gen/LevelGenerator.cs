using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : Singleton<LevelGenerator>
{   
    [SerializeField] private GameObject aStarPrefab;

    [Header("Level Parameters")]
    [SerializeField] private Level currentLevel;
    [SerializeField] private int spawnerCount;

    [Header("Section Prefabs")]
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
        GrabBag<GameObject> prefabBag = new GrabBag<GameObject>();
        foreach(GameObject prefab in sectionPrefabs)
            prefabBag.AddItem(prefab, 1);
        for (int i = 0; i <= CurrentLevel.maxSections; i++)
        {
            Vector2Int position = new Vector2Int(x, y);

            if (!SectionPlacementHandler.TryPlaceSection(prefabBag.Grab(), position, out Section currentSection))
                i--;
            int xStep = Random.Range(-1, 2);
            x += xStep;
            y += xStep == 0 ? Choose.Random(-1, 1) : 0;
        }
        foreach (Section section in CurrentLevel.sections)
            SectionPlacementHandler.PlaceBarriersAroundSection(section);
        PlacePlayer();
        GenerateAStarGraph();
        Debug.Log("Level generated.");
    }

    private void PlacePlayer()
    {
        Section spawnSection = CurrentLevel.sections[Random.Range(0, CurrentLevel.sections.Count)];
        Vector3 spawnPosition = new Vector3(spawnSection.position.x, 0, spawnSection.position.y) * 20 + new Vector3(-10, 0, 10);
        GameObject playerPrefab = Assets.Get<GameObject>("Player");
        PlayerInfo.playerObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity, ParentManager.Entities);
    }

    private void GenerateAStarGraph()
    {
        Vector3 position = CurrentLevel.sections[CurrentLevel.sections.Count / 2].transform.position;
        Instantiate(aStarPrefab, position, Quaternion.identity);
    }
}
