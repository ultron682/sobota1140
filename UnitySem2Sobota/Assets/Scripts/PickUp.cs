using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip audioClipPicked;

    public virtual void Picked() {
        Debug.Log("Podnioslem");
        MusicManager.Instance.PlayClipOneShot(audioClipPicked);
        Destroy(gameObject);
    }

    public void Rotate() {
        transform.Rotate(new Vector3(0,0,50 * Time.deltaTime));
    }
}
