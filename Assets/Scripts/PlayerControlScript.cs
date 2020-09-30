using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D r2d;
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        float x;
        if (countBlockDown > 0) {
            x = Input.GetAxis("Horizontal");
            r2d.velocity = new Vector2(x * speed, r2d.velocity.y);
        } else {
            x = 0;
        }
        animator.SetFloat("x", x);
        animator.SetBool("stop", x == 0f);
    }
    public int countBlockDown = 0;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BlockScript>() != null) {
            countBlockDown += 1;    
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BlockScript>() != null) {
            countBlockDown -= 1;
        }   
    }
}