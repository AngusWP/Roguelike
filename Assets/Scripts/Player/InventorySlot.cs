using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    GameObject item;
    bool full;

    public Image icon;
    public Button removeButton;

    public string name;

    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void addItem(GameObject it) {
        item = it;
        icon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
        it.transform.position = icon.transform.position;
        name = it.name;
        removeButton.interactable = true;
    }

    public bool isEmpty() {
        if (icon.enabled) {
            return false;
        }

        return true;
    }

    public void useItem() {
        if (item != null && name.Contains("Health Potion")) {
            if (player.GetComponent<Player>().hasFullHealth()) {
                return;
            }

            int min = item.GetComponent<Potion>().min;
            int max = item.GetComponent<Potion>().max;

            if (player.GetComponent<Player>().isInTutorial() && player.GetComponent<PlayerDialogue>().step == 1){
                player.GetComponent<PlayerDialogue>().goToNextStep();
            }

            player.GetComponent<Player>().heal(Random.Range(min, max));
            item.GetComponent<Potion>().play();

            clearSlot();
            Destroy(item);
        }
    }
    
    public void dropItem() {

        if (player.GetComponent<Player>().isInTutorial() && player.GetComponent<PlayerDialogue>().step == 1) {
            player.GetComponent<PlayerDialogue>().goToNextStep();
        }

        clearSlot();
    }

    public void clearSlot() {
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        Destroy(item);
    }
}
