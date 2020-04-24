using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform player;
    public float smoothing;
    public Vector3 offset;

    void Start() {

    }

    void Update() {
        if (player != null) {
            if (!player.GetComponent<Player>().isInCutscene()) {
                Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing * Time.deltaTime);
                transform.position = newPosition;
            }
        }
    }
}
