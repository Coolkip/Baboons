using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelectUnit : NetworkBehaviour {
    public Transform tile;

    public void Update() {
        Test();
    }

    public void Test() {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        tileMap.tiles[(int)tile.position.x, (int)tile.position.z].tilePassable = false;
        tileMap.tiles[(int)tile.position.x, (int)tile.position.z].tileOccupied = true;
    }
}