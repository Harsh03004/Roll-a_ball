using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Input.gyro.enabled = true;
    }

    void Update()
    {
        float moveHorizontal = Input.gyro.gravity.x;
        float moveVertical = Input.gyro.gravity.y;
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement.Normalize();
        rb.AddForce(movement * speed);
    }
}