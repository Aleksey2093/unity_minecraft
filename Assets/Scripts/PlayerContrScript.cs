using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class PlayerContrScript : MonoBehaviour {

    public Rigidbody2D r2d;

    void Start() {
        if (r2d == null) {
            r2d = GetComponent<Rigidbody2D>();
        }
    }

    public float x;
    public Vector2 speed;
    
    void Update() {
        countBlockDown.RemoveAll(item => !c2d.IsTouching(item));
        v2 = r2d.velocity;
    }

    public Vector2 v2;

    public float lastTimeSpace;
    
    void FixedUpdate() {
        if (countBlockDown.Count > 0) {
            x = Input.GetAxis("Horizontal") * speed.x;
            if (Input.GetKey(KeyCode.Space)) {
                r2d.AddForce(new Vector2(x, speed.y));
            }
            else {
                r2d.AddForce(new Vector2(0, 1f));
                r2d.velocity = new Vector2(x, r2d.velocity.y);
            }
        } else if (Input.GetKey(KeyCode.Space)) {
            r2d.AddForce(new Vector2(x, 0));
        }
    }

    public List<Collider2D> countBlockDown = new List<Collider2D>();
    public Collider2D c2d;

    private bool blockIsDown(Collision2D other) {
        if (c2d.bounds.min.y >= other.collider.bounds.max.y 
            && c2d.bounds.min.x < other.collider.bounds.max.x
            && c2d.bounds.max.x > other.collider.bounds.min.x) {
            return other.gameObject.GetComponent<BlockScript>() != null;
        }
        else {
            return false;
        }
    }
    //
    // void OnCollisionEnter2D(Collision2D other) {
    //     if (blockIsDown(other)) {
    //         countBlockDown.Add(other.collider);
    //     }
    // }

    private void OnCollisionStay2D(Collision2D other) {
        if (blockIsDown(other) && !countBlockDown.Contains(other.collider)) {
            countBlockDown.Add(other.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        countBlockDown.Remove(other.collider);
    }
}



