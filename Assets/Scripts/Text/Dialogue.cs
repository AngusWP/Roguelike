using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public Image dialogue;
    private Text text;
    public AudioSource dialogueNext;

    private bool finished = true;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        text = dialogue.GetComponentInChildren<Text>();
    }

    public void setText(string s) {
        text.text = s;
        AudioSource.PlayClipAtPoint(dialogueNext.clip, player.position);

        if (!hasText()) {
            dialogue.GetComponent<Image>().enabled = true;
            text.enabled = true;
        }
    }

    public bool isFinished() {
        return finished;
    }

    public void setFinished() {
        finished = true;
    }

    public void removeText() {
        if (hasText()) {
            dialogue.GetComponent<Image>().enabled = false;
            text.enabled = false;
        }
    }

    public bool hasText() {
        if (dialogue.GetComponent<Image>().enabled) {
            return true;
        }

        return false;
    }

}