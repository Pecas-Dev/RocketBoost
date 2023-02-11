using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speed = 10f;

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
        yValue = Input.GetAxis("Vertical");
        xValue = Input.GetAxis("Horizontal");
        zValue = Input.GetAxis("Horizontal");

        transform.Translate(0, yValue * speed * Time.deltaTime, 0);
        transform.Rotate(0, 0, -zValue * 200 * Time.deltaTime);
    }
}
