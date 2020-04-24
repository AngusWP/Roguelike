using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private Transform slotContainer;
    private GameObject ui;
    Inventory inv;

    public AudioSource pickup;

    InventorySlot[] slots;

    void Start() {
        ui = GameObject.FindGameObjectWithTag("UI");
        Transform inv = ui.transform.GetChild(0);
        slotContainer = inv.GetChild(0);
        slots = slotContainer.GetComponentsInChildren<InventorySlot>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {

            if (collision.GetComponent<Player>() != null){
                if (collision.GetComponent<PlayerDialogue>().step == 0) {
                    return;
                }
            }

            for (int i = 0; i < slots.Length; i++) {
                if (slots[i].isEmpty()) {
                    AudioSource.PlayClipAtPoint(pickup.clip, transform.position);
                    slots[i].addItem(gameObject);
                    return;
                }
            }
        }
    }
}
