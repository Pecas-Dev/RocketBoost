using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimator;

    [SerializeField] float transitionTime = 1.5f;
    [SerializeField] float mainMenuPlayButtonTime = 4f;

    CollisionHandler collisionHandler;

    
    void Start()
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
    }

    public IEnumerator Sandbox1Transition()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        collisionHandler.ReturnSandBox();
    }

    public IEnumerator Sandbox2Transition()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        collisionHandler.SandBox2();
    }

    public IEnumerator MainMenuTransition() 
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(mainMenuPlayButtonTime);

        SceneManager.LoadScene("Sandbox");
    }
}
