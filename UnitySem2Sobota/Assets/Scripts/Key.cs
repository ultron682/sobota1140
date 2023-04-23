using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public Material red;
    public Material green;
    public Material gold;
    public KeyColor keyColor;

    public override void Picked() {
        GameManager.Instance.AddKey(keyColor);
        base.Picked();
    }

    void Update() {
        Rotate();
    }

    private void Start() {
        SetMyColor();
    }

    void SetMyColor() {
        switch (keyColor) {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                break;
        }
    }
}
