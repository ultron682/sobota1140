using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {
    bool iCanOpen = false;
    public PortalDoor[] doors;
    public KeyColor keyColorToOpenDoor;
    bool locked = false;
    Animator animatorKey;


    void Start() {
        animatorKey = GetComponent<Animator>();
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked) {
            if (CheckTheKey())
                animatorKey.SetTrigger("OpenDoor");
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            iCanOpen = true;
            Debug.Log("Mozesz uzyć klucz");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            iCanOpen = false;
            Debug.Log("Nie mozesz uzyć klucz");
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
            locked = true;
            return true;
        }
        else if (keyColorToOpenDoor == KeyColor.Green && GameManager.Instance.greenKeysCount > 0) {
            GameManager.Instance.greenKeysCount--;
            locked = true;
            return true;
        }
        else if (keyColorToOpenDoor == KeyColor.Gold && GameManager.Instance.goldKeysCount > 0) {
            GameManager.Instance.goldKeysCount--;
            locked = true;
            return true;
        }
        else {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }
}
