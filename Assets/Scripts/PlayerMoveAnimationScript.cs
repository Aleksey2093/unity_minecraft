using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveAnimationScript : MonoBehaviour {
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    public Sprite[] rightAnimationSprite;
    public Sprite[] leftAnimationSprite;

    public int i;
    public MoveDirection direction = MoveDirection.None;

    public SpriteRenderer spriteRenderer;

    public float lastTimeChange;

    public PlayerContrScript playerContrScript;

    void Start() {
        if (spriteRenderer == null) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (playerContrScript == null) {
            playerContrScript = GetComponent<PlayerContrScript>();
        }
    }

    void Update() {
        if (playerContrScript.x > 0.1f) {
            if (MoveDirection.Right != direction) {
                direction = MoveDirection.Right;
                spriteRenderer.sprite = right;
                i = 0;
                lastTimeChange = Time.time;
            }
            else if (Time.time - lastTimeChange > 0.1f) {
                lastTimeChange = Time.time;
                if (i >= rightAnimationSprite.Length)
                    i = 0;
                else if (playerContrScript.r2d.velocity.x <= 0)
                    i = 0;
                spriteRenderer.sprite = rightAnimationSprite[i++];
            }
        }
        else if (playerContrScript.x < -0.1f) {
            if (MoveDirection.Left != direction) {
                direction = MoveDirection.Left;
                spriteRenderer.sprite = left;
                i = 0;
                lastTimeChange = Time.time;
            }
            else if (Time.time - lastTimeChange > 0.1f) {
                lastTimeChange = Time.time;
                if (i >= leftAnimationSprite.Length)
                    i = 0;
                else if (playerContrScript.r2d.velocity.x >= 0)
                    i = 0;
                spriteRenderer.sprite = leftAnimationSprite[i++];
            }
        }
        else if (MoveDirection.None != direction && Time.time - lastTimeChange > 0.1f) {
            lastTimeChange = Time.time;
            direction = MoveDirection.None;
            spriteRenderer.sprite = front;
        }
    }
}
