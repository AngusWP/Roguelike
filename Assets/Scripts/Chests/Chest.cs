using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject item;
    public float waitTime;
    private bool empty = false;

    private Animator anim;



    public Vector3 offset;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        
    }

    IEnumerator dropItem() {
            yield return new WaitForSeconds(waitTime);
            Instantiate(item, transform.position + offset, Quaternion.identity);
            empty = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.name == "Player") {
            anim.SetBool("interact", true);

            if (!empty) {
                StartCoroutine(dropItem());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") {
            anim.SetBool("interact", false);
        }
    }

}
