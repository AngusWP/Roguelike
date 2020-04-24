using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    public GameObject coin;

    public int percentChance;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Spell") {
            int rollChance = Random.Range(1, 100);

            if (percentChance >= rollChance) {
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            
        }
    }
}
