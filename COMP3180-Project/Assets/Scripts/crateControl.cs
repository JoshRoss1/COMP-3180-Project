using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crateControl : MonoBehaviour
{
    //Merge Fix
    //Drop logic
    public List<GameObject> drops;

    public GameObject playerOne;
    private Player1LootDrops playerOneLoot;

    public int playerOneTotal;
    public int playerOneRandomNumber;

    //Change sprite to animate opening crate.
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

        playerOneLoot = playerOne.GetComponent<Player1LootDrops>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.CompareTag("Player1"))
        {
            if (playerControls.actions["Interact"].triggered)
            {
                spriteRenderer.sprite = openSprite;
                isOpen = true;
                PlayerOneDrop();
            }
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            if (playerControls.actions["Interact"].triggered)
            {
                spriteRenderer.sprite = openSprite;
                isOpen = true;
                //PlayerTwoDrop();
            }
        }
    }

    private void PlayerOneDrop()
    {
        foreach (var item in playerOneLoot.lootTable)
        {
            playerOneTotal += item;
        }

        playerOneRandomNumber = Random.Range(0, playerOneTotal);

        for (int i = 0; i < playerOneLoot.lootTable.Length; i++)
        {
            if (playerOneRandomNumber <= playerOneLoot.lootTable[i])
            {
                //instantiate corresponding GameObject here.
                return;
            }
            else
            {
                playerOneRandomNumber -= playerOneLoot.lootTable[i];
            }
=======
        /*
         * Get reference to PlayerInput component of the player.
         * In this case the player is the Game Object of the collision.
         */
        playerControls = collision.gameObject.GetComponent<PlayerInput>();

        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Read input from PlayerInput and perform the method CrateOpen()
            playerControls.actions["Interact"].performed += ctx => CrateOpen();
>>>>>>> main
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

