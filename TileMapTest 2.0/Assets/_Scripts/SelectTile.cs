using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {
    public Transform tile;
    public Material material;
    public GameObject quad;

    public float activeTime;
    private float activeTimer;
    public int x, z, selectCounter, unitWalk = 4;

    Color color;

    private bool active;
    public bool selected;

    public void Awake()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        quad.SetActive(true);
        activeTimer = activeTime;
        active = true;
        color = Color.red;

    }

    public void Start() {
        quad.SetActive(false);
        x = (int)tile.position.x;
        z = (int)tile.position.z;
    }

    public void Update() {
        if (!active && activeTimer > 0) {
            activeTimer -= Time.deltaTime;
            if (activeTimer < 0) quad.SetActive(false);
        }
        if (active) active = !active;

        SelectedTile();
    }

    public void OnMouseOver() {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        quad.SetActive(true);
        activeTimer = activeTime;
        active = true;

        if (tileMap.tiles[x, z].tilePassable)
            color = Color.green;
        else
            color = Color.red;
        if (Input.GetMouseButtonDown(0)) {
            if (tileMap.tiles[x, z].tileOccupied) {
                if (selected) selected = false;
                else selected = true;
            }
        }
        quad.GetComponent<MeshRenderer>().material.color = color;
    }

    public void SelectedTile ()
    {
        if (selected)
        {
            TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
            quad.SetActive(true);
            activeTimer = activeTime;
            active = true;
            color = Color.yellow;

            for (int a = 1; a + x < tileMap.mapSizeX; a++)
            {
                if (a + x <= unitWalk + x)
                {

                    if (tileMap.tiles[x + a - 1, z].tileOccupied || !tileMap.tiles[x + a - 1, z].tilePassable)
                        tileMap.tiles[x + a, z].tileOccupied = true;
                    tileMap.tileObjects[x + a, z].GetComponent<SelectTile>().WalkableTile();
                }
            }

            for (int a = 1; x - a >= 0; a++)
            {
                if (a + x <= unitWalk + x)
                {
                    tileMap.tileObjects[x - a, z].GetComponent<SelectTile>().WalkableTile();
                    /*if (tileMap.tiles[x - a +1, z].tileOccupied || !tileMap.tiles[x - a +1, z].tilePassable)
                        color = Color.red; */
                }

            } 
               
            for (int a = 1; a + z < tileMap.mapSizeZ; a++)
            {
                if (a + z <= unitWalk + z)
                {
                    tileMap.tileObjects[x, z + a].GetComponent<SelectTile>().WalkableTile();
                    /*if (tileMap.tiles[x, z + a -1].tileOccupied || !tileMap.tiles[x, z + a -1].tilePassable)
                        color = Color.red; */
                }

            }

            for (int a = 1; z - a >= 0; a++)
            {
                if (a + z <= unitWalk + z)
                {
                    tileMap.tileObjects[x, z - a].GetComponent<SelectTile>().WalkableTile();
                    /*if (tileMap.tiles[x, z - a +1].tileOccupied || !tileMap.tiles[x, z - a +1].tilePassable)
                        color = Color.red; */
                }

            }      
        }

        quad.GetComponent<MeshRenderer>().material.color = color;
    }

    public void WalkableTile ()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        quad.SetActive(true);
        activeTimer = activeTime;
        active = true;
        if (tileMap.tiles[x, z].tilePassable)
            color = Color.green;
        else if (tileMap.tiles[x,z].tileOccupied)
            color = Color.red;
    }
}