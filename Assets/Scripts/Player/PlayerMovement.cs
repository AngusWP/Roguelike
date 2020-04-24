using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private string currentDirection = "right";
    private SpriteRenderer renderer;
    private Animator anim;
    private Vector3 change;
    private Rigidbody2D rb;

    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        updateMovement();
    }

    private void updateMovement() {

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit(); 
        }

        if (GetComponent<Player>().isInCutscene()) {
            anim.SetBool("moving", false);
            return; // make it so they can't move
        }

        if (Input.GetKey(KeyCode.A)) {
            currentDirection = "left";
        }

        if (Input.GetKey(KeyCode.D)) {
            currentDirection = "right";
        }

        if (!change.Equals(Vector3.zero)) { // so if its zero we know theyhaven't moved.
            anim.SetBool("moving", true);

            // add a way to check if an audio CLIP is playing (not an audio source).

            if (currentDirection.Equals("right")) {
                renderer.flipX = false;
            }

            if (currentDirection.Equals("left")) {
                renderer.flipX = true;
            }
;        } else {
            anim.SetBool("moving", false);
        }

        change.Normalize();
        rb.MovePosition(transform.position + (change * speed) * Time.deltaTime);

    }
}
