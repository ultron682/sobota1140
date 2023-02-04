using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField]
    private int timeToEnd = 15;
    bool endGame = false; // jesli gra sie zakoczny to wtedy true
    bool win = false;
    bool gamePaused = false;


    void Start() {
        if (Instance == null) {
            Instance = this;
        }

        InvokeRepeating("Stopper", 2, 1);
    }
    void Stopper() {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd);

        if (timeToEnd <= 0) {
            endGame = true;
        }

        if (endGame) {
            EndGame();
        }
    }
    void EndGame() {
        CancelInvoke("Stopper");

        if (win) {
            Debug.Log("You Win");
        }
        else {
            Debug.Log("You Lose");
        }
    }

    public void PauseGame() {
        Debug.Log("PauseGame");
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame() {
        Debug.Log("ResumeGame");
        Time.timeScale = 1;
        gamePaused = false;
    }

    void CheckPause() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    private void Update() {
        CheckPause();
    }
}
