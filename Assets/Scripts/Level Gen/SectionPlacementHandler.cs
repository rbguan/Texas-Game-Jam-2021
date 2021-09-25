using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SectionPlacementHandler 
{
    private const int ROOM_SIZE = 10;
    private const int TILE_SIZE = 2;

    private static Section currentBaseSection;

    public static bool TryPlaceSection(GameObject prefab, Vector2Int position, out Section section)
    {
        section = null;
        if (!LevelGenerator.CurrentLevel.grid.IsWithinBounds(position) ||
            LevelGenerator.CurrentLevel.grid[position])
            return false;
        Vector3 worldPosition = new Vector3(position.x, 0, position.y) * ROOM_SIZE * TILE_SIZE;
        GameObject gameObject = Object.Instantiate(prefab, worldPosition, Quaternion.identity, ParentManager.Level);
        section = gameObject.GetComponent<Section>();
        LevelGenerator.CurrentLevel.grid[position] = section;
        LevelGenerator.CurrentLevel.sections.Add(section);
        return true;
    }
}
