using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health;
    public float maxHealth;
    public float coins;
    
    public float spellDamage;
    public float spellCooldown;
    public float spellRadius;

    public bool cutscene;
    public bool inventory;

    public Slider healthBarSlider;
    public Text coinDisplay;
    public AudioSource playerHurt;
    public CameraShake camShake;
    public AudioSource spellCast;

    bool spellCD = false;

    public string hero = "Knight";

    private bool tutorial = true;

    public GameObject dialogueManager;

    void Start() {
        healthBarSlider.value = getHealthPercent();

        if (tutorial) {
            StartCoroutine(startTutorial());
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)){
            if (GetComponent<PlayerDialogue>().step == 4) {
                if (!(isInInventory()) && !(isOnCooldown())) {
                    useSpell();
                }
            }
        }
    }

    IEnumerator startTutorial() {
        yield return new WaitForSeconds(1);
        dialogueManager.GetComponent<Dialogue>().setText(GetComponent<PlayerDialogue>().getText());
    }

    public bool isOnCooldown() {
        return spellCD;
    }

    public void useSpell() {
        if (hero.Equals("Knight")) {
                
        }

        AudioSource.PlayClipAtPoint(spellCast.clip, transform.position);
        
        setCooldown(spellCooldown);
        spellCD = true;
    }

    public void setCooldown(float cd) {
        spellCooldown = cd;
        StartCoroutine(resetCD());
    }

    IEnumerator resetCD() {
        yield return new WaitForSeconds(spellCooldown);
        spellCD = false;
    }

    public bool isInTutorial() {
        return tutorial;
    }

    public bool isInInventory() {
        return inventory;
    }

    public bool hasFullHealth() {
        if (health == maxHealth) {
            return true;
        }

        return false;
    }
    public bool isInCutscene() {
        return cutscene;
    }
    public void heal(float heal) {
        health += heal;

        if (health > maxHealth) {
            health = maxHealth;
        }

        healthBarSlider.value = getHealthPercent();
    }
    
    public void takeDamage(float damage) {
        health -= damage;
        StartCoroutine(camShake.shake(.15f, .09f));

        AudioSource.PlayClipAtPoint(playerHurt.clip, transform.position);

        if (health <= 0) {
            health = 0;
            healthBarSlider.value = 0;
            kill();
        } else {
            healthBarSlider.value = getHealthPercent();
        }
    }

    public float getCoins() {
        return coins;
    }

    public void addCoins(float amount) {
        coins += amount;

        updateCoinUI();
    }

    public void takeCoins(float amount) {
        coins -= amount;

        if (coins == 0) {
            coins = 0;
        }

        updateCoinUI();
    }

    public void updateCoinUI() {
        coinDisplay.text = "" + coins;
    }

    public bool hasEnoughCoins(float amount) {
        if (coins >= amount) {
            return true;
        }

        return false;
    }

    public float getHealthPercent() {
        return (health / maxHealth);
    }

    public void kill() {
        Destroy(gameObject);
    }
}
