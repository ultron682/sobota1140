using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public Transform door;
    private Vector3 openPosition;
    private Vector3 closePosition;

    public bool open = false;
    public float Speed = 10;


    void Start()
    {
        closePosition = transform.GetChild(0).position;
        openPosition = closePosition + new Vector3(0,-6,0);
    }
 
    void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition) > 0.01f) {
            door.position = Vector3.MoveTowards(door.position, openPosition, Speed * Time.deltaTime );
        }

        if (!open && Vector3.Distance(door.position, closePosition) > 0.01f) {
            door.position = Vector3.MoveTowards(door.position, closePosition, Speed * Time.deltaTime);
        }
    }

    public void SwitchDoorState() {
        open = !open;
    }
}
