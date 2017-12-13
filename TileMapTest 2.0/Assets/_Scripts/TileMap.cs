using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TileMap : MonoBehaviour {

    public TileType[] tileTypes;
    public GameObject[,] tileObjects;
    int[,] tiles;
    int mapSizeX = 10, mapSizeY = 10;

    void Start() {
        tileObjects = new GameObject[mapSizeX, mapSizeY];
        tiles = new int[mapSizeX, mapSizeY];

        AllocateMap();
        GenerateMap();
    }

    public void AllocateMap() {
        for (int x = 0; x < mapSizeX; x++)
            for (int z = 0; z < mapSizeY; z++)
                tiles[x, z] = TileType.TYPE_PLAIN;

        for (int x = 2; x < 4; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = TileType.TYPE_MOUNTAIN;

        for (int x = 6; x < 8; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = TileType.TYPE_LAKE;
    }

    public void GenerateMap() {
        for (int x = 0; x < mapSizeX; x++)
            for (int z = 0; z < mapSizeY; z++)
                tileObjects[x, z] = Instantiate(tileTypes[tiles[x, z]].tileVisualPrefab, new Vector3(x, 0, z), Quaternion.identity);
    }
}