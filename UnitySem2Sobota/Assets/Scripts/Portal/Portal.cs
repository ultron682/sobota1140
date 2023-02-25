using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherPortal;
    public Material material;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;
    float myAngle;


    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.GetComponent<Transform>();

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null) {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.SetMyAngle(myAngle);
    }

    private void Start() {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
        CheckAngle();
    }

    public float GetMyAngle() {
        return myAngle;
    }

    void CheckAngle() {
        if (Mathf.Abs(otherPortal.GetMyAngle() - GetMyAngle()) != 180) {
            Debug.LogWarning("Portale nie są odpowiednio obrócone" + gameObject.name);
        }
    }
}
