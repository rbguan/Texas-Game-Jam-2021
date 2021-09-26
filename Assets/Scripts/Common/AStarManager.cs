using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStarManager : MonoBehaviour
{
    public AstarPath navMap;
    private bool navCalculated;

    private void Update()
    {
        if (!navCalculated)
            CalculateNavMap();
    }

    private void CalculateNavMap()
    {
        GridGraph graph = (GridGraph) navMap.graphs[0];
        graph.center = transform.position;
        graph.Scan();
        navCalculated = true;
    }
}
