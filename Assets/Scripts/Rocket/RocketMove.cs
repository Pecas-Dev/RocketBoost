using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    [SerializeField] float speedThrust = 100f;
    [SerializeField] float rotationThrust = 50f;

    Rigidbody rocketRb;

    float yValue;
    float xValue;
    float zValue;

    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //yValue = Input.GetAxis("Vertical");
        //xValue = Input.GetAxis("Horizontal");
        //zValue = Input.GetAxis("Horizontal");

        RelativeForce();
        Rotation();

        //transform.Translate(0, yValue * speedhTrust * Time.deltaTime, 0);
        //transform.Rotate(0, 0, -zValue * 200 * Time.deltaTime);
    }

    void RelativeForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRb.AddRelativeForce(Vector3.up * speedThrust * Time.deltaTime);
        }
    }

    void Rotation()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotationMovement(rotationThrust);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotationMovement(-rotationThrust);
        }
    }

    void RotationMovement(float rotation)
    {
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
    }
}
