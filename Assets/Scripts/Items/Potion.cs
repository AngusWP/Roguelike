using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public int min = 10;
    public int max = 30;

    public AudioSource drink;

    public void play() {
        AudioSource.PlayClipAtPoint(drink.clip, GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
