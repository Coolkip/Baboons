using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {
    public Transform tile;

    public void OnMouseOver() {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();

        if (Input.GetMouseButtonDown(0)) {

            if (tileMap.selectionObjects[(int)tile.position.x, (int)tile.position.z].activeSelf)
                tileMap.selectionObjects[(int)tile.position.x, (int)tile.position.z].SetActive(false);
            else {
                for (int x = 0; x < tileMap.mapSizeX; x++) {
                    for (int z = 0; z < tileMap.mapSizeY; z++) {
                        if (tileMap.selectionObjects[x, z].activeSelf)
                            tileMap.selectionObjects[x, z].SetActive(false);
                        if (!tileMap.selectionObjects[x, z].activeSelf)
                            tileMap.selectionObjects[(int)tile.position.x, (int)tile.position.z].SetActive(true);
                    }
                }
            }
        }
    }
}