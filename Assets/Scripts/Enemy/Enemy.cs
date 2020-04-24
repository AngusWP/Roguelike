using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float health;
    public float maxHealth;
    
    public GameObject healthBar;
    public Slider healthBarSlider;

    public float minDamage, maxDamage, attackRadius, aggroRadius, moveSpeed, attackCD;
    public Transform target;

    public bool ranged; // so we can code their movement, we dont want archers to rush face first at the player.
    
    private Transform homePosition;
    private Animator anim;
    private SpriteRenderer renderer;

    public Rigidbody2D rb;
    public GameObject blood;
    public AudioSource death;

    private AudioClip deathClip;

    private float oldPos; // this is to check left and right
    private bool justAttacked;
    private bool aggro;

    void Start() {
        health = maxHealth;
        homePosition = transform;
        oldPos = transform.position.x;

        deathClip = death.clip;

        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        checkRadius();

    }
    
    public void checkRadius() {

        if (target == null) {
            anim.SetBool("moving", false);
            return;
        }

        if (target.GetComponent<Player>() != null) {
            if (target.GetComponent<Player>().isInCutscene()) {
                anim.SetBool("moving", false);
                return; // make it so they can't move or attack
            }
        }

        if (Vector3.Distance(target.position, transform.position) <= aggroRadius && Vector3.Distance(target.position, transform.position) > attackRadius && !justAttacked) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
     
            if (oldPos > transform.position.x) { // left
                renderer.flipX = true;
            }
            else if (oldPos < transform.position.x) { // right
                renderer.flipX = false;
            }

            oldPos = transform.position.x; // update it

            anim.SetBool("moving", true);
            aggro = true;
        }
        else if (Vector3.Distance(target.position, transform.position) > aggroRadius) {
            anim.SetBool("moving", false);
        }

        if (Vector3.Distance(target.position, transform.position) < attackRadius && !justAttacked) {
            justAttacked = true;

            if (target.GetComponent<Player>() != null) {
                target.GetComponent<Player>().takeDamage(getDamage());
            }

            // add a knockback feature which sends the playerr back

            anim.SetBool("moving", false);
            StartCoroutine(attackCooldown());
        }
    }
    
    IEnumerator attackCooldown() {
        yield return new WaitForSeconds(attackCD);
        justAttacked = false;
    }

    public float getDamage() {
        return Random.Range(minDamage, maxDamage);
    }

    public void dealDamage(float damage) {

        if (!aggro) {
            return;
        }

        health -= damage;

        if (health <= 0) {
            GameObject particle = Instantiate(blood, transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(deathClip, transform.position);

            Destroy(gameObject);
            healthBar.SetActive(false);

            
        } else {
            healthBarSlider.value = getHealthPercent();
            healthBar.SetActive(true);
        }
    }

    public void heal(float amount) {
        health += amount;

        if (health > maxHealth) {
            health = maxHealth; // stop any overhealing
        }

        healthBarSlider.value = getHealthPercent();
    }

    private float getHealthPercent() {
        return (health / maxHealth);
    }


}
