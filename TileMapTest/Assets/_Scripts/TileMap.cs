using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TileMap : NetworkBehaviour {
    GameManagement gameManagement;
    public TileType[] tileTypes;
    public GameObject[,] tileObjects;

    int[,] tiles;

    int mapSizeX = 10, mapSizeY = 10;

    void Start() {
        if (!isLocalPlayer) return;
        gameManagement = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();

        tileObjects = new GameObject[mapSizeX, mapSizeY];

        tiles = new int[mapSizeX, mapSizeY];
        for (int x = 0; x < mapSizeX; x++)
            for (int z = 0; z < mapSizeY; z++)
                tiles[x, z] = TileType.TYPE_PLAIN;

        tiles[0, 0] = TileType.TYPE_MOUNTAIN;
        tiles[9, 9] = TileType.TYPE_MOUNTAIN;

        for (int x = 2; x < 4; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = TileType.TYPE_LAKE;

        for (int x = 6; x < 8; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = TileType.TYPE_LAKE;

        GenerateMap();
    }

    public void GenerateMap() {
        for (int x = 0; x < mapSizeX; x++)
            for (int z = 0; z < mapSizeY; z++)
                tileObjects[x, z] = Instantiate(tileTypes[tiles[x, z]].tileVisualPrefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
    }

    public void DestroyTile(int x, int y) {
        Debug.Log("Destroying: " + x + ", " + y);
        tileObjects[x, y].SetActive(false);
    }

    public Vector2 DestroyTile(GameObject g) {
        for (int x = 0; x < mapSizeX; x++) {
            for (int y = 0; y < mapSizeY; y++) {
                if (tileObjects[x, y] == g) {
                    gameManagement.DestroyTile(x, y);
                    return new Vector2(x, y);
                }
            }
        }
        return new Vector2(0, 0);
    }
}