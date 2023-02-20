using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float thrust = 200f;
    private void OnEnable()
    {
        EventManager.OnThrowUp += ThrowBallUp;
        EventManager.OnThrowLeft += ThrowBallLeft;
        EventManager.OnThrowRight += ThrowBallRight;
    }

    private void OnDisable()
    {
        EventManager.OnThrowUp -= ThrowBallUp;
        EventManager.OnThrowLeft -= ThrowBallLeft;
        EventManager.OnThrowRight -= ThrowBallRight;
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
}
