using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour {

    public GameObject dialogueManager;

    public int step = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (dialogueManager.GetComponent<Dialogue>().hasText()){
                if (dialogueManager.GetComponent<Dialogue>().isFinished()) {
                    if (step == 4) {
                        dialogueManager.GetComponent<Dialogue>().removeText();
                        return; // for now
                    }
                    
                    if (step == 0 || step == 3) {
                        goToNextStep();
                    }   
                } else {
                    dialogueManager.GetComponent<Dialogue>().setFinished();
                }
            }
        }
    }

    public void goToNextStep() {
        dialogueManager.GetComponent<Dialogue>().removeText();
        step++;
        StartCoroutine(next());
    }

    IEnumerator next() {
        yield return new WaitForSeconds(1);
        dialogueManager.GetComponent<Dialogue>().setText(getText());
    }

    public string getText() {
        if (step == 0) {
            return "Use WASD to move. Press space to continue.";
        }

        if (step == 1) {
            return "You are injured! Walk up to that health potion and open your inventory by pressing E. Either click on the potion to use it, or click on the red X to remove it.";
        }

        if (step == 2) {
            return "Good job! Now, can you try find a way out of this room? Right click to fire your attack.";
        }

        if (step == 3) {
            return "You have picked up some coins! You can use coins to buy new armour, which could increase your damage, speed and health.";
        }

        if (step == 4) {
            return "Now, use what you have learned to fight your way out of this dungeon! Here's a tip - left click to perform your hero's special ability!";
        }

        return "";
    }
}
