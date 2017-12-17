using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType {
    public enum Type { PLAIN, MOUNTAIN, LAKE, SELECTIONQUAD };

    public TileType(TileType source) {
        type = source.type;
        name = source.name;
        tilePassable = source.tilePassable;
        tileOccupied = source.tileOccupied;
        tileVisualPrefab = source.tileVisualPrefab;
    }

    public Type type;
    public string name;
    public bool tilePassable, tileOccupied;
    public GameObject tileVisualPrefab;
}