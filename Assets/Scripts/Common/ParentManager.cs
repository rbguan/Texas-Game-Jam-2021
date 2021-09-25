using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentManager : MonoBehaviour
{
    private const string ENTITIES = "--- Entities ---";

    private static Transform entities;

    public static Transform Entities => Find(ref entities, ENTITIES);

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private static Transform Find(ref Transform transform, string name)
    {
        if (!transform)
            transform = GameObject.Find(name)?.transform;
        if (transform)
            return transform;
        throw new Exception("Could not find parent transform named " + name);
    }
}