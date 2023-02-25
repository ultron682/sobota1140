using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    float myAngle = 0;


    private void Update() {
        PortalCameraController();
    }

    public void SetMyAngle(float angle) {
        myAngle = angle;
    }

    void PortalCameraController() {
        Vector3 playerOffSetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = playerOffSetFromPortal + portal.position;

        float angularDiffBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if (myAngle == 90 || myAngle == 270) {
            angularDiffBetweenPortalRotations -= 90;
        }

        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDiff * playerCamera.forward;

        if (myAngle == 90 || myAngle == 270) {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y, newCameraDirection.x);

            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);

            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }



    }
}
