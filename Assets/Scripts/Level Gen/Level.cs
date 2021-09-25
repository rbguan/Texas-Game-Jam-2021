using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    private const int MAX_SIZE = 100;

    [Header("Parameters")]
    public int maxSections;

    [Header("Runtime")]
    public TGrid<Section> grid = new TGrid<Section>(MAX_SIZE, MAX_SIZE);
    public List<Section> sections = new List<Section>();
    public HashSet<Vector2Int> barriers = new HashSet<Vector2Int>();
}
