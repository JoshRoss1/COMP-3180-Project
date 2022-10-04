using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector2 i_movement;
    float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, i_movement.y, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    void OnMoveUp()
    {
        transform.Translate(transform.up);
    }

}
