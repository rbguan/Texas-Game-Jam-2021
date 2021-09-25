using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabLoader 
{
    public static void LoadAllAtPath()
    {
        GameObject[] resources = UnityEngine.Resources.LoadAll<GameObject>("Prefabs/");
        foreach (GameObject resource in resources)
            Assets.Add(resource.name, resource);
        Debug.Log("Loaded prefabs.");
    }
}
