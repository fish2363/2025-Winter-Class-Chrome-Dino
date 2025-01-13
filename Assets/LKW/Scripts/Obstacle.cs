using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2d.linearVelocityX = -moveSpeed;
    }
}
