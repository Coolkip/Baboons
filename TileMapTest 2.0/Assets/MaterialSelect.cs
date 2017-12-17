using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelect : MonoBehaviour {

    public Material material;

    void Start() {
        GetComponent<MeshRenderer>().material = new Material(material);
    }
}
