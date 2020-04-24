using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float damage;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Enemy") {
            if (collision.GetComponent<Player>() != null) {
                collision.GetComponent<Player>().takeDamage(damage);
            }

            if (collision.tag == "Pickup") {
                return; // we want it to keep going
            }

            Destroy(gameObject);
        }
    }

}
