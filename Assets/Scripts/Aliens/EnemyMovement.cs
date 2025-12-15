using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int startDirection = 1;
    private int currentDirection;
    private float halfWidth;
    private float halfHeight;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
        currentDirection = startDirection;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rigidBody.linearVelocity.y;
        rigidBody.linearVelocity = movement;
        SetDirection();
    }


    private void SetDirection()
    {
        Vector2 rightPos = transform.position;
        Vector2 leftPos = transform.position;
        rightPos.x += halfWidth;
        leftPos.x -= halfWidth;

        if (rigidBody.linearVelocity.x > 0)
        {
            if(Physics2D.Raycast(transform.position, Vector2.right, halfWidth + 0.1f, LayerMask.GetMask("Ground")))
            {
                // Draw a ray starting at the centre of our enemy and point it to the right
                // Check to see if the raycast is intersecting with a wall
                // Check to make sure the enemy is walking right
                // If this doesn't happen, the enemy will be constantly moving back and forth
            currentDirection *= -1;
            spriteRenderer.flipX = false;
            }
            else if (!Physics2D.Raycast(rightPos, Vector2.down, halfHeight + 0.1f, LayerMask.GetMask("Ground")))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = false;
            }
        }

        else if (rigidBody.linearVelocity.x < 0)
            {
                if (Physics2D.Raycast(transform.position, Vector2.left, halfWidth + 0.1f, LayerMask.GetMask("Ground")))
                {
                    currentDirection *= -1;
                    spriteRenderer.flipX = true;
                }
                else if (!Physics2D.Raycast(leftPos, Vector2.down, halfHeight + 0.1f, LayerMask.GetMask("Ground")))
                {
                    currentDirection *= -1;
                    spriteRenderer.flipX = true;
                }
            }
    }
}