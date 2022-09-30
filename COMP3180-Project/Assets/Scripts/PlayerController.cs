using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 1f;

    //Testing


    //Component References
    public Rigidbody2D playerRB;

    //Input Actions References
    private PlayerControls playerControls;
    private Vector2 move;

    private void Awake()
    {
        playerControls = new PlayerControls();


        playerControls.PlayerOneMovement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerControls.PlayerOneMovement.Move.canceled += ctx => move = Vector2.zero;



    }

    void Start()
    {
        Debug.Log(InputSystem.devices.ToArray());
    }

    private void FixedUpdate()
    {

        playerRB.velocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
        
    }

    private void Update()
    {
        
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
