using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    float speed = 12f;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;

    private float startSpeed;


    void Start() {
        characterController = GetComponent<CharacterController>();
        startSpeed = speed;
    }

    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        RaycastHit hit; // zmienna w której zapisywana jest referencja do uderzonego obiektu
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
            out hit, 0.4f, groundMask)) {
            string tagGround = hit.collider.gameObject.tag;

            switch (tagGround) {
                default:
                    speed = startSpeed;
                    break;
                case "LowSpeed":
                    speed = startSpeed * 0.7f;
                        break;
                case "HighSpeed":
                    speed = startSpeed * 2.5f;
                    break;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.collider.gameObject.tag == "PickUp") {
            hit.collider.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
