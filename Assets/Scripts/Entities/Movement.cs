using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : EntityPart
{
    private const float MIN_SPEED_TO_STOP = 0.05f;

    public float speed;
    [Range(0f,1f)] public float friction;
    public Vector2 movementVector;

    private void FixedUpdate()
    {
        if (movementVector.magnitude > 0)
        {
            parent.Body.MovePosition(parent.Body.position + new Vector3(movementVector.x, 0, movementVector.y) * Time.fixedDeltaTime);
            movementVector *= friction;
            if (movementVector.magnitude < MIN_SPEED_TO_STOP)
                movementVector = Vector2.zero;
        }
    }

    public void Move(Vector2 direction)
    {
        movementVector = direction * speed;
    }
}
