using System.Collections;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    SceneTransition transition;

    public AudioSource playButtonAudioSource;
    public AudioClip playButtonHoverAudioClip;
    public AudioClip playButtonPressedAudioClip;

    public AudioSource musicSource;

    bool isPlayPressed = false;
    float fadeOutDuration = 2.5f;
    float fadeOutStartTime;

    void Start()
    {
        transition = FindObjectOfType<SceneTransition>();
    }

    private void Update()
    {
        if (isPlayPressed)
        {
            float elapsedTime = Time.time - fadeOutStartTime;
            float currentVolume = musicSource.volume;
            float targetVolume = 0f;
            if (elapsedTime < fadeOutDuration)
            {
                float volumeStep = currentVolume * Time.deltaTime / fadeOutDuration;
                targetVolume = Mathf.Max(currentVolume - volumeStep, 0f);
            }
            else
            {
                targetVolume = 0f;
            }
            musicSource.volume = targetVolume;
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
        fadeOutStartTime = Time.time;
    }

    public void PlayButtonTransition()
    {
        StartCoroutine(WaitTransitionTime());

        IEnumerator WaitTransitionTime()
        {
            yield return new WaitForSeconds(fadeOutDuration);
            StartCoroutine(transition.MainMenuTransition());
        }
    }
}
