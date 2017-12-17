using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class TileMap : MonoBehaviour {

    public GameObject[,] tileObjects;
    //public GameObject[,] selectionObjects;
    //public Material[,] selectionMaterials;
    public TileType[,] tiles;
    //public TileType[,] selections;
    public TileType[] tileTypes;
    public int mapSizeX = 10, mapSizeZ = 10;
    
    void Start() {
        tileObjects = new GameObject[mapSizeX, mapSizeZ];
        //selectionObjects = new GameObject[mapSizeX, mapSizeZ];

        //selectionMaterials = new Material[mapSizeX, mapSizeZ];
        //selectionObjects = new GameObject[mapSizeX, mapSizeZ];
        //unitSelectionObjects = new GameObject[mapSizeX, mapSizeZ];

        tiles = new TileType[mapSizeX, mapSizeZ];
        //selections = new TileType[mapSizeX, mapSizeZ];

        AllocateMap();
        GenerateMap();
    }

    public void AllocateMap() {
        for (int x = 0; x < mapSizeX; x++) {
            for (int z = 0; z < mapSizeZ; z++) {
                    tiles[x, z] = new TileType(tileTypes[(int)TileType.Type.PLAIN]);
                    //selections[x, z] = tileTypes[(int)TileType.Type.SELECTIONQUAD];
                    //tileSelections[x, z] = SelectionType.TYPE_WALKABLE;
                    //unitSelections[x, z] = SelectionType.TYPE_SELECTUNIT;
            }                
        }
            
        for (int x = 2; x < 4; x++)
            for (int z = 4; z < 6; z++)
                tiles[x, z] = new TileType(tileTypes[(int)TileType.Type.MOUNTAIN]);

        for (int x = 6; x < 8; x++) {
            for (int z = 4; z < 6; z++) {
                tiles[x, z] = new TileType(tileTypes[(int)TileType.Type.LAKE]);
                //tileSelections[x, z] = SelectionType.TYPE_NOTWALKABLE;
                //unitSelections[x, z] = SelectionType.TYPE_NOTWALKABLE;
            }
        }            
    }

    public void GenerateMap() {
        for (int x = 0; x < mapSizeX; x++) {
            for (int z = 0; z < mapSizeZ; z++) {
                tileObjects[x, z] = Instantiate(tiles[x, z].tileVisualPrefab, new Vector3(x, 0, z), Quaternion.identity);
                
                
                
                
                
                //tileObjects[x, z].transform.GetChild(0).GetComponent<MeshRenderer>().material = new Material(tileObjects[x, z].transform.GetChild(0).GetComponent<MeshRenderer>().material);
                //selectionObjects[x, z] = Instantiate(selections[x, z].tileVisualPrefab, new Vector3(x, 0.51f, z), Quaternion.Euler(90, 0, 0));
                //selectionObjects[x, z].SetActive(false);
                
            
            
            
                //selectionObjects[x, z] = Instantiate(selectionTypes[tileSelections[x, z]].selectionVisualPrefab, new Vector3(x, 0.51f, z), Quaternion.Euler(90, 0, 0));
                //selectionObjects[x, z].SetActive(false);
                //unitSelectionObjects[x, z] = Instantiate(selectionTypes[unitSelections[x, z]].selectionVisualPrefab, new Vector3(x, 0.51f, z), Quaternion.Euler(90, 0, 0));
                //unitSelectionObjects[x, z].SetActive(false);
            }
        }
    }
}