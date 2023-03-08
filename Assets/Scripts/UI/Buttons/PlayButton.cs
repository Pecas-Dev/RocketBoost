using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    SceneTransition transition;

    public AudioSource playButtonAudioSource;
    public AudioClip playButtonHoverAudioClip;
    public AudioClip playButtonPressedAudioClip;

    public AudioSource musicSource;

    bool isPlayPressed = false;

    void Start()
    {
        transition = FindObjectOfType<SceneTransition>();
    }

    private void Update()
    {
        if (isPlayPressed == true)
        {
            musicSource.volume = musicSource.volume - 0.0005f;
        }
    }

    public void PlayHoverSound()
    {
        playButtonAudioSource.PlayOneShot(playButtonHoverAudioClip);
    }

    public void PlayPressedSound()
    {
        playButtonAudioSource.PlayOneShot(playButtonPressedAudioClip);
        isPlayPressed = true;
    }

    public void PlayButtonTransition()
    {
        StartCoroutine(WaitTransitionTime());

        IEnumerator WaitTransitionTime()
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(transition.MainMenuTransition());
        }
    }
}
