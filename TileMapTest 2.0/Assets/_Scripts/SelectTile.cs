using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {
    public Transform tile;
    public Material material;
    public GameObject quad;

    public float activeTime;
    private float activeTimer;
    public int x, z;

    Color color;

    private bool active;

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
        quad.GetComponent<MeshRenderer>().material.color = color;
        if (Input.GetMouseButtonDown(0)) {  
            if(!tileMap.tiles[x, z].tileOccupied) {
                Debug.Log("Hier! Suck a kok");
            }
        }
    }
}