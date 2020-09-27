using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraGeneratorScript : MonoBehaviour {
    public Transform grassOriginal;
    public Transform dirtOriginal;
    public Transform stoneOriginal;
    public int size;
    
    void Start()
    {
        Generate_v2_by_object(grassOriginal,-2);
        // Generate_v2_by_object(dirtOriginal,-3);
        // Generate_v2_by_object(stoneOriginal,-4);
    }

    void Generate_v2_by_object(Transform original, float y) {
        GameObject.Instantiate(
            original.transform,
            new Vector3(0,y),
            new Quaternion(),
            this.transform);
        for (float i = 1; i <= size; i++) {
            GameObject.Instantiate(original,
                new Vector3(i,y),
                new Quaternion(),
                this.transform);
            GameObject.Instantiate(original,
                new Vector3(-i,y),
                new Quaternion(),
                this.transform);
        }
    }
}





