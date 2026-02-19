using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip gameStartClip; // Audio clip to play at game start
    public AudioClip buttonClickClip; // Audio clip to play when a button is clicked

    void Start()
    {
        // Play the game start audio
        PlayClip(gameStartClip);
    }

    public void PlayButtonClickAudio()
    {
        // Play the button click audio
        PlayClip(buttonClickClip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}