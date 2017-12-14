using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectionType {
    public static int TYPE_WALKABLE = 0;
    public static int TYPE_NOTWALKABLE = 1;

    public string name;
    public GameObject selectionVisualPrefab;
}
