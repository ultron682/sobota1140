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

    public int points = 0;
    public int redKeysCount = 0;
    public int greenKeysCount = 0;
    public int goldKeysCount = 0;

    void Start() {
        if (Instance == null) {
            Instance = this;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    private void Update() {
        CheckPause();
        CheckPickUps();
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

    void CheckPickUps() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("Actual time: " + timeToEnd);
            Debug.Log("Red: " + redKeysCount + " green: " + greenKeysCount + " gold: " + goldKeysCount);
            Debug.Log("Points: " + points);
        }
    }

    public void AddPoints(int points) {
        this.points += points;
    }

    public void AddTime(int time) {
        timeToEnd += time;
    }

    public void FreezTime(int time) {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", time, 1);
    }

    public void AddKey(KeyColor keyColor) {
        if (keyColor == KeyColor.Red) {
            redKeysCount++;
        }
        else if (keyColor == KeyColor.Green) {
            greenKeysCount++;
        }
        else  {
            goldKeysCount++;
        }
    }
}

public enum KeyColor {
    Red,
    Green,
    Gold
}


