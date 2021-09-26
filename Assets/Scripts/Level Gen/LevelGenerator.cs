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

    [Header("Spawner Prefabs")]
    [SerializeField] private List<GameObject> spawnerPrefabs = new List<GameObject>();

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
        GrabBag<Section> sectionBag = new GrabBag<Section>();
        foreach(Section section in CurrentLevel.sections)
            sectionBag.AddItem(section, 1);
        GrabBag<GameObject> spawnerBag = new GrabBag<GameObject>();
        foreach(GameObject prefab in spawnerPrefabs)
            spawnerBag.AddItem(prefab, 1);
        for (int i = 0; i <= spawnerCount; i++)
        {
            if (!TryAddSpawnerToSection(sectionBag.Grab(), spawnerBag.Grab()))
                i--;
        }
        PlacePlayer();
        PlacePortal();
        GenerateAStarGraph();
        Debug.Log("Level generated.");
    }

    private bool TryAddSpawnerToSection(Section section, GameObject spawner)
    {
        if (!CanAddSpawnerToSection(section, out Vector2Int position))
            return false;
        Vector2Int direction = position - section.position;
        Vector3 origin = section.transform.position + new Vector3(10, 0, 10);
        Vector3 offset = new Vector3(Random.Range(0, 9) * direction.x, 0, Random.Range(0, 9) * direction.y);
        Vector3 worldPosition = offset + origin;
        if (Physics.CheckSphere(worldPosition + Vector3.up * 2f, 2f, LayerMask.GetMask("Bounds")))
            return false;
        Instantiate(spawner, worldPosition, Quaternion.identity, ParentManager.Level);
        return true;
    }

    private bool CanAddSpawnerToSection(Section section, out Vector2Int position)
    {
        Vector2Int sectionPosition = section.position;
        position = sectionPosition;
        for (int xOffset = -1; xOffset <= 1; xOffset++)
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                Vector2Int offset = new Vector2Int(xOffset, yOffset);
                position = sectionPosition + offset;
                if (!CurrentLevel.grid.IsWithinBounds(position) || CurrentLevel.barriers.Contains(position))
                    return true;
            }
        return false;
    }

    private void PlacePlayer()
    {
        Section spawnSection = CurrentLevel.sections[Random.Range(0, CurrentLevel.sections.Count)];
        Vector3 spawnPosition = new Vector3(spawnSection.position.x, 0, spawnSection.position.y) * 20 + new Vector3(-10, 1, 10);
        GameObject playerPrefab = Assets.Get<GameObject>("Player");
        if (!PlayerInfo.playerObject)
            PlayerInfo.playerObject = Instantiate(playerPrefab);
        PlayerInfo.playerObject.transform.position = spawnPosition;
        PlayerStats playerStats = PlayerInfo.playerObject.GetComponent<PlayerStats>();
        playerStats.CurrentHealth = playerStats.fullHealth;
        PlayerLightning playerLightning = PlayerInfo.playerObject.GetComponent<PlayerLightning>();
        playerLightning.ResetRodsForNextRound();
        FollowerCamera.SnapToPlayer();
        FollowerCamera.Current.target = PlayerInfo.playerObject.transform;
    }

    private void PlacePortal()
    {
        GameObject portalPrefab = Assets.Get<GameObject>("Portal");
        LevelInfo.portalObject = Instantiate(
            portalPrefab, PlayerInfo.playerObject.transform.position, Quaternion.identity, ParentManager.Level);
        LevelInfo.portalObject.SetActive(false); 
    }

    private void GenerateAStarGraph()
    {
        Vector3 position = CurrentLevel.sections[CurrentLevel.sections.Count / 2].transform.position;
        Instantiate(aStarPrefab, position, Quaternion.identity);
    }
}
