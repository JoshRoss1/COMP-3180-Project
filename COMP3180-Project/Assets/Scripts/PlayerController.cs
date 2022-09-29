using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 1f;

    //Component References
    public Rigidbody2D playerRB;

    //Input Actions References
    private PlayerControls playerControls;
    private Vector2 move;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerControls.Movement.Move.canceled += ctx => move = Vector2.zero;

    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

}
