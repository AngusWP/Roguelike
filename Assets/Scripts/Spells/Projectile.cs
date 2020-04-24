using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name != "Player") {
            if (collision.GetComponent<Enemy>() != null) {
                collision.GetComponent<Enemy>().dealDamage(damage);
            }

            if (collision.tag == "Pickup") {
                return; // we don't want it to break on hitting an item
            }

            Destroy(gameObject);
        } 
    }

}
