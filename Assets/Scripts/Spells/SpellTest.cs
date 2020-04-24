using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTest : MonoBehaviour{

    public GameObject projectile;
    public float minDamage, maxDamage;
    public float projectileForce;


    public AudioSource shootSound;
    private AudioClip clip;

    private Vector2 direction;

    void Start(){
        clip = shootSound.clip;
    }

    void Update(){
        if (Input.GetMouseButtonDown(1)) {

            if (GetComponent<Player>() != null) {
                if (GetComponent<Player>().isInCutscene() || GetComponent<Player>().isInInventory() || GetComponent<PlayerDialogue>().step < 2) {
                    return;
                }
            }
            
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
        
            AudioSource.PlayClipAtPoint(clip, transform.position);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 characterPos = transform.position;
            Vector2 direction = (mousePos - characterPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
