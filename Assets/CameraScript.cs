using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float distX;
    public float distY;
    
    void Start()
    {
        Vector3 zero = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 one = Camera.main.ViewportToWorldPoint(Vector3.one);
        distX = one.x * 0.2f;
        distY = one.y * 0.2f;
    }
    
    void Update() {
        Vector3 cP = Camera.main.transform.position;
        Vector3 p = transform.position;
        float x = Mathf.Clamp(cP.x, p.x - distX, p.x + distX);
        float y = Mathf.Clamp(cP.y, p.y - distY, p.y + distY);
        Camera.main.transform.position = new Vector3(x, y, cP.z);
    }
}
