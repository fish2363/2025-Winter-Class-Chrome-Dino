using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
