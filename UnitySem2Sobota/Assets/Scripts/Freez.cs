using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : PickUp
{
    public int freezTime = 10;


    public override void Picked() {
        GameManager.Instance.FreezTime(freezTime);
        base.Picked();
    }

    void Update() {
        Rotate();
    }
}
