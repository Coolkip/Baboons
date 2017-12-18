using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour
{
    public Transform tile;
    public Material material;
    public GameObject quad;
    public GameObject mouseOverQuad;
    public float activeTime = 1f;


    public int x, z, selectCounter, unitWalk = 4;

    Color color;
    
    public bool selected;

    private Stack<GameObject> enabledTiles;

    public void Awake()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        quad.SetActive(true);
        color = Color.red;

    }

    public void Start()
    {
        enabledTiles = new Stack<GameObject>();
        quad.SetActive(false);
        x = (int)tile.position.x;
        z = (int)tile.position.z;
    }

    public void Update()
    {

    }

    public void OnMouseOver()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        //quad.SetActive(true);
        GameObject newQuad = Instantiate(mouseOverQuad, transform.position + Vector3.up * 0.51f, Quaternion.Euler(90, 0, 0)) as GameObject;
        Destroy(newQuad, activeTime);

        if (tileMap.tiles[x, z].tilePassable)
            color = Color.green;
        else if (tileMap.tiles[x, z].tileOccupied)
            color = Color.yellow;
        else
            color = Color.red;
        if (Input.GetMouseButtonDown(0))
        {
            if (tileMap.currentlySelected.x == -1 && tileMap.tiles[x,z].tileOccupied)
            {
                if (tileMap.tiles[x, z].tileOccupied)
                {
                    SelectedTile();

                    tileMap.currentlySelected = new Vector2(x, z);
                }
            }
            else if (tileMap.tiles[x, z].tileOccupied)
            {
                if (tileMap.currentlySelected == new Vector2(x, z))
                {
                    UnselectTile();

                    tileMap.currentlySelected = new Vector2(-1, -1);
                }
                else
                {
                    tileMap.tileObjects[(int)tileMap.currentlySelected.x, (int)tileMap.currentlySelected.y].GetComponent<SelectTile>().UnselectTile();
                    SelectedTile();
                    tileMap.currentlySelected = new Vector2(x, z);
                }

            }


        }
        newQuad.GetComponent<MeshRenderer>().material.color = color;
    }

    public void UnselectTile()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        while(enabledTiles.Count > 0)
        {
            enabledTiles.Pop().GetComponent<SelectTile>().WalkableTile(false);
        }
    }

    public void SelectedTile()
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();

        for (int a = 1; a + x < tileMap.mapSizeX; a++)
        {
            if (a + x <= unitWalk + x)
            {

                if (tileMap.tiles[x + a, z].tileOccupied || !tileMap.tiles[x + a, z].tilePassable) break;
                enabledTiles.Push(tileMap.tileObjects[x+a, z]);
                tileMap.tileObjects[x + a, z].GetComponent<SelectTile>().WalkableTile(true);
            }
        }

        for (int a = 1; x - a >= 0; a++)
        {
            if (a + x <= unitWalk + x)
            {
                if (tileMap.tiles[x - a, z].tileOccupied || !tileMap.tiles[x - a, z].tilePassable) break;
                enabledTiles.Push(tileMap.tileObjects[x - a, z]);
                tileMap.tileObjects[x - a, z].GetComponent<SelectTile>().WalkableTile(true);

            }

        }

        for (int a = 1; a + z < tileMap.mapSizeZ; a++)
        {
            if (a + z <= unitWalk + z)
            {
                if(tileMap.tiles[x, z + a].tileOccupied || !tileMap.tiles[x, z + a].tilePassable) break;
                enabledTiles.Push(tileMap.tileObjects[x, z + a]);
                tileMap.tileObjects[x, z + a].GetComponent<SelectTile>().WalkableTile(true);

            }

        }

        for (int a = 1; z - a >= 0; a++)
        {
            if (a + z <= unitWalk + z)
            {

                if (tileMap.tiles[x, z - a].tileOccupied || !tileMap.tiles[x, z - a].tilePassable) break;
                enabledTiles.Push(tileMap.tileObjects[x, z - a]);
                tileMap.tileObjects[x, z - a].GetComponent<SelectTile>().WalkableTile(true);
            }

        }

        quad.GetComponent<MeshRenderer>().material.color = color;
    }

    public void WalkableTile(bool activate)
    {
        TileMap tileMap = GameObject.FindWithTag("Overworld").GetComponent<TileMap>();
        quad.SetActive(activate);
        color = Color.yellow;
        if (!activate)
            return;
        if (tileMap.tiles[x, z].tilePassable)
            color = Color.green;
        else if (tileMap.tiles[x, z].tileOccupied)
            color = Color.red;
        quad.GetComponent<MeshRenderer>().material.color = color;
    }
}