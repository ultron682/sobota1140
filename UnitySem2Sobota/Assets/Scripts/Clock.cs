using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public int timeToAdd = 4;

    public override void Picked() {
        GameManager.Instance.AddTime(timeToAdd);
        base.Picked();
    }


    void Update()
    {
        Rotate();
    }
}
