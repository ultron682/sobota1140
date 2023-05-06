using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {
    bool iCanOpen = false;
    public PortalDoor[] doors;
    public KeyColor keyColorToOpenDoor;
    bool locked = false;
    Animator animatorKey;
    public GameObject NextLevel;
    public Material red;
    public Material green;
    public Material gold;


    void Start() {
        animatorKey = GetComponent<Animator>();
        SetMyColor();
    }

    void SetMyColor() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        switch (keyColorToOpenDoor) {
            case KeyColor.Red:
                renderers[0].material = red;
                renderers[1].material = red;
                break;
            case KeyColor.Green:
                renderers[0].material = green;
                renderers[1].material = green;
                break;
            case KeyColor.Gold:
                renderers[0].material = gold;
                renderers[1].material = gold;
                break;
        }
    }

    void Update() {
        if (iCanOpen && !locked) {
            GameManager.Instance.SetUseInfo("Press E to open LOCK");
        }

        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked) {
            if (CheckTheKey()) {
                animatorKey.SetTrigger("OpenDoor");
                if (NextLevel != null) {
                    NextLevel.SetActive(true);
                }
            }
                
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            iCanOpen = true;
            //Debug.Log("Mozesz uzyć klucz");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            iCanOpen = false;
            //Debug.Log("Nie mozesz uzyć klucz");
            GameManager.Instance.SetUseInfo(string.Empty);
        }
    }

    public void UseKey() {
        foreach (PortalDoor door in doors) {
            door.SwitchDoorState();
        }
    }

    public bool CheckTheKey() {
        if (keyColorToOpenDoor == KeyColor.Red && GameManager.Instance.redKeysCount > 0) {
            GameManager.Instance.redKeysCount--;
            GameManager.Instance.Text_redKey.text = GameManager.Instance.redKeysCount.ToString();

            locked = true;
            return true;
        }
        else if (keyColorToOpenDoor == KeyColor.Green && GameManager.Instance.greenKeysCount > 0) {
            GameManager.Instance.greenKeysCount--;
            GameManager.Instance.Text_greenKey.text = GameManager.Instance.greenKeysCount.ToString();

            locked = true;
            return true;
        }
        else if (keyColorToOpenDoor == KeyColor.Gold && GameManager.Instance.goldKeysCount > 0) {
            GameManager.Instance.goldKeysCount--;
            GameManager.Instance.Text_goldKey.text = GameManager.Instance.goldKeysCount.ToString();

            locked = true;
            return true;
        }
        else {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }
}
