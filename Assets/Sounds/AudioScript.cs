using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioPlayer1;
    public AudioSource audioPlayer2;
    public AudioClip battleSong;
    public AudioClip waveSound;

    public bool canPlay1 = false;
    public bool canPlay2 = false;

    void Update()
    {
        if (canPlay1 == true)
        {
            audioPlayer1.clip = battleSong;
            audioPlayer1.Play();
            canPlay1 = false;
        }
        if (canPlay2 == true)
        {
            audioPlayer2.clip = waveSound;
            audioPlayer2.Play();
            canPlay2 = false;
        }
    }
}
