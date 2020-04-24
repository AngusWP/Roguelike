using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int space = 12;
    public List<GameObject> items;

    public GameObject inventory;

    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown("e") && !GetComponent<Player>().isInCutscene()) {
            inventory.SetActive(!inventory.activeInHierarchy);
            GetComponent<Player>().inventory = !GetComponent<Player>().inventory;
        }
    }
}
