using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGJGame : Singleton<TGJGame>
{
    private const int INITIAL_WAIT_SECONDS = 2;
    private const int WAIT_BETWEEN_WAVES_SECONDS = 3;

    [SerializeField] private int waves;
    [SerializeField] private GameObject findWayToExitText;

    private WaitForSeconds initialWait = new WaitForSeconds(INITIAL_WAIT_SECONDS);
    private WaitForSeconds waitBetweenWaves = new WaitForSeconds(WAIT_BETWEEN_WAVES_SECONDS);

    protected override void Awake()
    {
        base.Awake();
        PrefabLoader.LoadAllAtPath();
    }
    
    private void Start()
    {
        LevelGenerator.Current.GenerateLevel();
        StartCoroutine(GameRoutine());
        AudioManager.Current.PlayGameMusic();
    }

    public IEnumerator GameRoutine()
    {
        yield return initialWait;
        Debug.Log("First wave spawning!");
        for (int i = 0; i < waves; i++)
        { 
            SpawnWave();
            yield return new WaitUntil(IsWaveDead);
            yield return waitBetweenWaves;
        }
        UnlockPortal();
    }

    private void SpawnWave()
    {
        foreach (EntitySpawner spawner in EntitySpawner.spawners)
            spawner.SpawnEntity();
    }

    private bool IsWaveDead()
    {
        if (Entity.entities.Count == 0)
            return true;
        return false;
    }

    private void UnlockPortal()
    {
        LevelInfo.portalObject.SetActive(true);
        findWayToExitText?.SetActive(true);
    }
}
