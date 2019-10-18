using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class AppearanceGenerator : MonoBehaviour
{
    private void Start() {
        var mat = GetComponent<MeshRenderer>().materials[0];
        mat.color = new Color(Random.value, Random.value, Random.value);
    }
}
