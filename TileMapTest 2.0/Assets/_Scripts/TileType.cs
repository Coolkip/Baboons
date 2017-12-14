using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType {
    public static int TYPE_PLAIN = 0;
    public static int TYPE_MOUNTAIN = 1;
    public static int TYPE_LAKE = 2;

    public string name;
    public bool tilePassable, tileOccupied;
    public GameObject tileVisualPrefab;
}