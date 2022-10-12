using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crateControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen = false;
    private bool interacting = false;

    PlayerInput playerControls;

    private void Awake()
    {

    }

    void Start()
    {
        spriteRenderer.sprite = closedSprite;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * Get reference to PlayerInput component of the player.
         * In this case the player is the Game Object of the collision.
         */
        playerControls = collision.gameObject.GetComponent<PlayerInput>();

        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Read input from PlayerInput and perform the method CrateOpen()
            playerControls.actions["Interact"].performed += ctx => CrateOpen();
        }
    }

    void CrateOpen()
    {
        //Everything to do when the crate is opened
        spriteRenderer.sprite = openSprite;
        isOpen = true;
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
