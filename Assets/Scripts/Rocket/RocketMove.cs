using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    [SerializeField] float speedThrust = 100f;
    [SerializeField] float rotationThrust = 50f;

    [SerializeField] public ParticleSystem[] sideThrustParticles = new ParticleSystem[2];

    [SerializeField] AudioClip thrusters;    
    public AudioSource thrustAudio;

    Rigidbody rocketRb;

    float yValue;
    float xValue;
    float zValue;

    CollisionHandler collisionHandler;

    void Start()
    {
        thrustAudio = GetComponent<AudioSource>();
        rocketRb = GetComponent<Rigidbody>();
        collisionHandler = FindObjectOfType<CollisionHandler>();
    }


    void Update()
    {
        //yValue = Input.GetAxis("Vertical");
        //xValue = Input.GetAxis("Horizontal");
        //zValue = Input.GetAxis("Horizontal");

        RelativeForce();
        Rotation();
        PlayThrustSound();

        //transform.Translate(0, yValue * speedTrust * Time.deltaTime, 0);
        //transform.Rotate(0, 0, -zValue * 200 * Time.deltaTime);
    }


    void RelativeForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRb.AddRelativeForce(Vector3.up * (speedThrust * Time.deltaTime));
        }
    }

    void PlayThrustSound()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thrustAudio.PlayOneShot(thrusters);
            collisionHandler.rocketParticles[0].Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            thrustAudio.Stop();
            collisionHandler.rocketParticles[0].Stop();
        }
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotationMovement(rotationThrust);

            if (!sideThrustParticles[0].isPlaying && !sideThrustParticles[1].isPlaying)
            {
                sideThrustParticles[0].Play();
            }
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotationMovement(-rotationThrust);

            if (!sideThrustParticles[1].isPlaying && !sideThrustParticles[0].isPlaying)
            {
                sideThrustParticles[1].Play();
            }
        }

        else
        {
            sideThrustParticles[0].Stop();
            sideThrustParticles[1].Stop();
        }
    }

    void RotationMovement(float rotation)
    {
        rocketRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * (rotation * Time.deltaTime));
        rocketRb.freezeRotation = false;
    }
}
