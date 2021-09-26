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
        section.position = position;
        LevelGenerator.CurrentLevel.grid[position] = section;
        LevelGenerator.CurrentLevel.sections.Add(section);
        return true;
    }

    public static void PlaceBarriersAroundSection(Section section)
    {
        Vector2Int startPosition = section.position;
        TGrid<Section> grid = LevelGenerator.CurrentLevel.grid;
        for (int xOffset = -1; xOffset <= 1; xOffset++)
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                Vector2Int offset = new Vector2Int(xOffset, yOffset);
                Vector2Int position = startPosition + offset;
                if (!grid.IsWithinBounds(position))
                {
                    if (!IsBarrierInPosition(position))
                        PlaceBarrier(position);
                }
                else if (!grid[position] && !IsBarrierInPosition(position))
                    PlaceBarrier(position);
            }
    }

    private static bool IsBarrierInPosition(Vector2Int position) => 
        LevelGenerator.CurrentLevel.barriers.Contains(position);

    private static void PlaceBarrier(Vector2Int position)
    {
        GameObject prefab = Assets.Get<GameObject>("Barrier Section");
        Vector3 worldPosition = new Vector3(position.x, 0, position.y) * ROOM_SIZE * TILE_SIZE;
        GameObject gameObject = Object.Instantiate(prefab, worldPosition, Quaternion.identity, ParentManager.Level);
        LevelGenerator.CurrentLevel.barriers.Add(position);
    }
}
