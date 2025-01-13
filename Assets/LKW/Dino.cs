using System;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public int jumpPower = 5;
    public bool canJump = true;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    private Vector2 originSize;
    private Vector2 originOffset;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        originSize = boxCollider2D.size;
        originOffset = boxCollider2D.offset;
    }

    private void Update()
    {
        TryJump();
        Down();
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Down()
    {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            boxCollider2D.offset = new Vector2(originOffset.x, originOffset.y -0.25f);
            boxCollider2D.size = new Vector2(originSize.x, originSize.y/2);
        }
        else
        {
            boxCollider2D.offset = originOffset;
            boxCollider2D.size = originSize;
        }
    }
    
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
