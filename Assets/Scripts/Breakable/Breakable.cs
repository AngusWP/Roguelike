using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    private Animator anim;

    public void Start() {
        anim = GetComponent<Animator>();
    }

    public void Stop() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Spell") {
            anim.SetBool("broken", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(removeObject());
        }
    }

    IEnumerator removeObject() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
