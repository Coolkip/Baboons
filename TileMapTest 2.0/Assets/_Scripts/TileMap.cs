using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class TileMap : MonoBehaviour {
    public TileType[] tileTypes;
    public GameObject[,] tileObjects;
    int[,] tiles;

    public int mapSizeX = 10, mapSizeY = 10;

    public SelectionType[] selectionTypes;
    public GameObject[,] selectionObjects;
    int[,] selections;

    void Start() {
        tileObjects = new GameObject[mapSizeX, mapSizeY];
        selectionObjects = new GameObject[mapSizeX, mapSizeY];

        tiles = new int[mapSizeX, mapSizeY];
        selections = new int[mapSizeX, mapSizeY];

        AllocateMap();
        GenerateMap();
    }

    public void AllocateMap() {
        for (int x = 0; x < mapSizeX; x++) {
            for (int z = 0; z < mapSizeY; z++) {
                    tiles[x, z] = TileType.TYPE_PLAIN;
                    selections[x, z] = SelectionType.TYPE_WALKABLE;
            }                
        }
            
        for (int x = 2; x < 4; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = TileType.TYPE_MOUNTAIN;

        for (int x = 6; x < 8; x++) {
            for (int z = 4; z < 6; z++) {
                tiles[x, z] = TileType.TYPE_LAKE;
                selections[x, z] = SelectionType.TYPE_NOTWALKABLE;
            }                
        }            
    }

    public void GenerateMap() {
        for (int x = 0; x < mapSizeX; x++) {
            for (int z = 0; z < mapSizeY; z++) {
                tileObjects[x, z] = Instantiate(tileTypes[tiles[x, z]].tileVisualPrefab, new Vector3(x, 0, z), Quaternion.identity);
                selectionObjects[x, z] = Instantiate(selectionTypes[selections[x, z]].selectionVisualPrefab, new Vector3(x, 0.51f, z), Quaternion.Euler(90, 0, 0));
                selectionObjects[x, z].SetActive(false);
            }
        }
    }
}