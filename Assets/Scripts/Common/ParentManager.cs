using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentManager : MonoBehaviour
{
    private const string ENTITIES = "--- Entities ---";
    private const string LEVEL = "--- Level ---";
    private const string TEMP = "--- Temp ---";

    private static Transform entities;
    private static Transform level;
    private static Transform temp;

    public static Transform Entities => Find(ref entities, ENTITIES);

    public static Transform Level => Find(ref level, LEVEL);

    public static Transform Temp => Find(ref temp, TEMP);

    private static Transform Find(ref Transform transform, string name)
    {
        if (!transform)
            transform = GameObject.Find(name)?.transform;
        if (transform)
            return transform;
        throw new Exception("Could not find parent transform named " + name);
    }
}