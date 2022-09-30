using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 1f;

    [Tooltip("Enable to turn on GamePad controls. Disable for K&M")]
    [Header("Gamepad or Keyboard and Mouse?")]
    public bool enableGamepad = false;

    //Component References
    public Rigidbody2D playerRB;

    //Input Actions References
    private PlayerControls gamepadControls;
    private PlayerControls keyboardControls;
    private Vector2 move;

    private void Awake()
    {
        gamepadControls = new PlayerControls();
        keyboardControls = new PlayerControls();

        if (enableGamepad)
        {
            gamepadControls.PlayerOneMovement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            gamepadControls.PlayerOneMovement.Move.canceled += ctx => move = Vector2.zero;
        }

        if (!enableGamepad)
        {
            keyboardControls.KeyboardMovement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            keyboardControls.KeyboardMovement.Move.canceled += ctx => move = Vector2.zero;
        }
        

        



    }

    void Start()
    {

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
        gamepadControls.Enable();
        keyboardControls.Enable();
    }

    private void OnDisable()
    {
        gamepadControls.Disable();
        keyboardControls.Disable();
    }

}
