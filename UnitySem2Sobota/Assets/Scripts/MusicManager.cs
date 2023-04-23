using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager Instance;
    AudioSource audioSource;

    public AudioClip clipResume;
    public AudioClip clipPause;
    public AudioClip clipWin;
    public AudioClip clipLose;


    void Start() {
        if (Instance == null)
            Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClipOneShot(AudioClip clipToPlay) {
        audioSource.PlayOneShot(clipToPlay);
    }

    public void ChangeMainClip(AudioClip clipToPlay) {
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }
}
