using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Controls References
    private PlayerInput playerControls;
    public GameObject playerManager;

    //Movement Variables
    Vector2 i_movement;
    float moveSpeed = 10f;



    private void Awake()
    {
        playerControls = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /*
     The below is Movement related
     */
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

    /*
     The below is Weapon and Aiming Related
     */
    

    /*
     The below is Player Input related
     */
    public void PlayerInputInitialise(PlayerInput playerInput)
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.actions.Enable();
    }

    private void OnDisable()
    {
        playerControls.actions.Disable();
    }
}
