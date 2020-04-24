using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // menu = 0, options = 1, game = 2

    public void startGame() {
        SceneManager.LoadScene(2);
    }

    public void showOptions() {
        SceneManager.LoadScene(1);
    }

    public void goBackToMenu() {
        SceneManager.LoadScene(0);
    }
    
    public void exitGame() {
        Application.Quit();
        // this only works if the game is built, doesn't work in the Unity editor.
    }
}
