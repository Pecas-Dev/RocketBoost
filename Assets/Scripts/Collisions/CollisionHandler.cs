using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip[] rocketCurrentState;

    AudioSource rocketAudioSource;

    SceneTransition sceneTransition;
    RocketMove rocketMove;

    bool isTransition = false;

    void Start()
    {
        rocketAudioSource = GetComponent<AudioSource>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        rocketMove = FindObjectOfType<RocketMove>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isTransition) 
        {
            return;
        }

        if (!isTransition)
        {
            switch (collision.gameObject.tag)
            {
                case "TakeOff":
                    Debug.Log("You are in the Take-Off zone");
                    break;

                case "Fuel":
                    Debug.Log("You touched the fuel");
                    break;

                case "End":
                    Debug.Log("You finished!");

                    if (SceneManager.GetActiveScene().name == "Sandbox")
                    {
                        Win();
                        StartCoroutine(sceneTransition.Sandbox2Transition());
                        //SandBox2();
                    }

                    if (SceneManager.GetActiveScene().name == "Sandbox2")
                    {
                        Win();
                        StartCoroutine(sceneTransition.Sandbox1Transition());
                        //ReturnSandBox();
                    }

                    break;

                default:
                    Debug.Log("You Crashed");
                    Crash();
                    StartCoroutine(RestartSandBox());
                    break;
            }
        }
    }

    IEnumerator RestartSandBox()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SandBox2()
    {
        SceneManager.LoadScene("Sandbox2");
    }

    public void ReturnSandBox()
    {
        SceneManager.LoadScene("Sandbox");
    }

    void Win()
    {
        //rocketMove.thrustAudio.enabled = false;
        isTransition = true;
        rocketAudioSource.Stop();
        rocketAudioSource.PlayOneShot(rocketCurrentState[0]);
        rocketMove.enabled = false;
    }

    void Crash()
    {
        isTransition = true;
        rocketAudioSource.Stop();
        rocketAudioSource.PlayOneShot(rocketCurrentState[1]);
        rocketMove.enabled = false;
    }
}
