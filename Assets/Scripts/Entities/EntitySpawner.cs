using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public static List<EntitySpawner> spawners = new List<EntitySpawner>();

    [Serializable]
    public struct Spawn
    {
        public GameObject prefab;
        public float weight;
    }

    public List<Spawn> spawns = new List<Spawn>();

    private void OnEnable()
    {
        spawners.Add(this);
    }

    private void OnDisable()
    {
        spawners.Remove(this);
    }

    public void SpawnEntity()
    {

    }
}
