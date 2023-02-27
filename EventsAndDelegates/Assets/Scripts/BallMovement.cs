using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float thrust = 200f;
    private float baseThrust = 200f;

    public TMP_Text velocityText;

    InputAction moveUp = new InputAction("up", binding: "<Keyboard>/w");
    InputAction moveLeft = new InputAction("left", binding: "<Keyboard>/a");
    InputAction moveRight = new InputAction("right", binding: "<Keyboard>/d");

    private void OnEnable()
    {
        EventManager.OnThrowUp += ThrowBallUp;
        EventManager.OnThrowLeft += ThrowBallLeft;
        EventManager.OnThrowRight += ThrowBallRight;

        EventManager.OnIncreaseThrust += IncreaseThrust;

        moveUp.performed += ctx => ThrowBallUp();
        moveLeft.performed += ctx => ThrowBallLeft();
        moveRight.performed += ctx => ThrowBallRight();


        moveUp.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }

    private void OnDisable()
    {
        EventManager.OnThrowUp -= ThrowBallUp;
        EventManager.OnThrowLeft -= ThrowBallLeft;
        EventManager.OnThrowRight -= ThrowBallRight;

        EventManager.OnIncreaseThrust -= IncreaseThrust;

        moveUp.Disable();
        moveLeft.Disable();
        moveRight.Disable();
    }

    void Update()
    {
        velocityText.text = "Velocity \n X: " + RoundFloat(rb.velocity.x) + " \n Y: " + RoundFloat(rb.velocity.y);
    }

    void ThrowBallUp()
    {
        rb.AddForce(0,thrust,0);
    }

    void ThrowBallLeft()
    {
        rb.AddForce(-thrust, 0, 0);
    }

    void ThrowBallRight()
    {
        rb.AddForce(thrust, 0, 0);
    }

    void IncreaseThrust(float multiplier)
    {
        thrust = thrust * multiplier;
    }

    float RoundFloat(float num)
    {
        return Mathf.Round(num * 10.0f) * 0.1f;
    }
}
