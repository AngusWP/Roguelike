using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {

    public AudioSource pickup;
    private AudioClip pickupClip;

    public int pauseTime;

    private Collider2D player;

    public GameObject door;

    public void Start() {
        pickupClip = pickup.clip;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            player = collision;
            collision.GetComponent<Player>().cutscene = true;
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(startCutscene());
        }
    }

    IEnumerator startCutscene() {
        yield return new WaitForSeconds(1);
            Vector3 doorPos = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z - 1);
            Camera.main.transform.position = doorPos;
            door.GetComponent<Animator>().SetBool("open", true);
        yield return new WaitForSeconds(pauseTime);
        Destroy(gameObject);
        player.GetComponent<Player>().cutscene = false;
        door.GetComponent<BoxCollider2D>().enabled = false;
    }
}
