using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityFactory 
{
    public static Entity Build(string name, Vector3 position)
    {
        GameObject prefab = Assets.Get<GameObject>(name);
        return null;
    }
}
