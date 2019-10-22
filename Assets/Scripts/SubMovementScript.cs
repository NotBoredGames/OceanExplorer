using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovementScript : MonoBehaviour
{
    [SerializeField]
    Vector2 bounds = new Vector2(368, 480);

    Rigidbody2D body;
    RectTransform rect;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        horizontal = ((rect.localPosition.x - 2f) <= -bounds.x && horizontal < 0) ? 0 : horizontal;
        horizontal = ((rect.localPosition.x + 2f) >= bounds.x && horizontal > 0) ? 0 : horizontal;
        vertical = ((rect.localPosition.y - 2f) <= -bounds.y && vertical < 0) ? 0 : vertical;
        vertical = ((rect.localPosition.y + 2f) >= bounds.y && vertical > 0) ? 0 : vertical;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal != 0 || vertical != 0) // Check for any movement
        {
            body.velocity = body.velocity + new Vector2(horizontal * runSpeed, vertical * runSpeed) * Time.fixedDeltaTime;
        }
        else
        {
            body.velocity = body.velocity;
        }
    }
}
