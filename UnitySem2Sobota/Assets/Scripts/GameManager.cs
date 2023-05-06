using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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


    public Text Text_time;
    public Text Text_redKey;
    public Text Text_greenKey;
    public Text Text_goldKey;
    public Text Text_crystals;
    public Image Image_snowFlake;

    public GameObject infoPanel;
    public GameObject gamePanel;
    public Text Text_useInfo;
    public Text Text_info;


    void Start() {
        if (Instance == null) {
            Instance = this;
        }

        if (timeToEnd <= 0) {
            timeToEnd = 100;
        }
        Image_snowFlake.enabled = false;
        Text_time.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        SetUseInfo(string.Empty);

        InvokeRepeating("Stopper", 2, 1);
    }

    public void SetUseInfo(string text) {
        Text_useInfo.text = text;
    }

    private void Update() {
        CheckPause();
        CheckPickUps();
    }

    void Stopper() {
        timeToEnd--;
        Text_time.text = timeToEnd.ToString();
        Image_snowFlake.enabled = false;

        //Debug.Log("Time: " + timeToEnd);

        if (timeToEnd <= 0) {
            endGame = true;
        }

        if (endGame) {
            EndGame();
        }
    }
    void EndGame() {
        CancelInvoke("Stopper");
        infoPanel.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;

        if (win) {
            MusicManager.Instance.PlayClipOneShot(MusicManager.Instance.clipWin);
            Text_info.text = "You win!!";
        }
        else {
            MusicManager.Instance.PlayClipOneShot(MusicManager.Instance.clipLose);
            Text_info.text = "You lose!!";
        }
    }

    public void PauseGame() {
        //Debug.Log("PauseGame");
        if (endGame == false) {
            Time.timeScale = 0;
            infoPanel.SetActive(true);
            gamePaused = true;
            MusicManager.Instance.ChangeMainClip(MusicManager.Instance.clipPause);
        }
    }

    public void ResumeGame() {
        //Debug.Log("ResumeGame");
        if (endGame == false) {
            Time.timeScale = 1;
            infoPanel.SetActive(false);
            gamePaused = false;
            MusicManager.Instance.ChangeMainClip(MusicManager.Instance.clipResume);
        }
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
        Text_crystals.text = this.points.ToString();
    }

    public void AddTime(int time) {
        timeToEnd += time;
        Text_time.text = timeToEnd.ToString();
    }

    public void FreezTime(int time) {
        CancelInvoke("Stopper");
        Image_snowFlake.enabled = true;
        InvokeRepeating("Stopper", time, 1);
    }

    public void AddKey(KeyColor keyColor) {
        if (keyColor == KeyColor.Red) {
            redKeysCount++;
            Text_redKey.text = redKeysCount.ToString();
        }
        else if (keyColor == KeyColor.Green) {
            greenKeysCount++;
            Text_greenKey.text = greenKeysCount.ToString();
        }
        else  {
            goldKeysCount++;
            Text_goldKey.text = goldKeysCount.ToString();
        }
    }
}

public enum KeyColor {
    Red,
    Green,
    Gold
}


