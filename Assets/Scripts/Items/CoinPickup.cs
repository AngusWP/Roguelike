using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int minAmount;
    public int maxAmount;

    public AudioSource pickup;
    private AudioClip pickupClip;

    public void Start() {
        pickupClip = pickup.clip;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            collision.GetComponent<Player>().addCoins(Random.Range(minAmount, maxAmount));


            if (collision.GetComponent<PlayerDialogue>().step == 2) {
                collision.GetComponent<PlayerDialogue>().goToNextStep();
            }
            
            
            AudioSource.PlayClipAtPoint(pickupClip, collision.GetComponent<Player>().transform.position);
            Destroy(gameObject);
        }
    }
}
