using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crateControl : MonoBehaviour
{

    //
    private EnviroManager crateC;

    //Drop logic
    public GameObject[] drops;

    public GameObject playerOne;
    private Player1LootDrops playerOneLoot;

    public int playerOneTotal;
    public int playerOneRandomNumber;

    public GameObject playerTwo;
    private Player2LootDrops playerTwoLoot;

    public int playerTwoTotal;
    public int playerTwoRandomNumber;

    //Change sprite to animate opening crate.
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    public bool isOpen = false;

    PlayerInput playerControls;

    private void Awake()
    {
        playerControls = GetComponentInParent<PlayerInput>();
    }

    void Start()
    {
        spriteRenderer.sprite = closedSprite;

        playerOneLoot = playerOne.GetComponent<Player1LootDrops>();

        playerTwoLoot = playerTwo.GetComponent<Player2LootDrops>();
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

        //Read input from PlayerInput and perform the method CrateOpen()
        //playerControls.actions["Interact"].performed += ctx => CrateOpenP1();

        if (collision.gameObject.CompareTag("Player1"))
        {
            playerControls.actions["Interact"].performed += ctx => CrateOpenP1();
            isOpen = true;
            crateC.crateCount--;

        } else
        {
            isOpen = false;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            playerControls.actions["Interact"].performed += ctx => CrateOpenP2();
            isOpen = true;
            crateC.crateCount--;
        } else
        {
            isOpen = false;
        }
    }

    void CrateOpenP1()
    {
        //Everything to do when the crate is opened
        spriteRenderer.sprite = openSprite;
        PlayerOneDrop();
    }

    void CrateOpenP2()
    {
        //Everything to do when the crate is opened
        spriteRenderer.sprite = openSprite;
        PlayerTwoDrop();
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

                Debug.Log("You recieved :" + drops[i].name);
                Instantiate(drops[i], transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }
            else
            {
                playerOneRandomNumber -= playerOneLoot.lootTable[i];
            }
        }
    }

    private void PlayerTwoDrop()
    {
        foreach (var item in playerTwoLoot.lootTable)
        {
            playerTwoTotal += item;
        }

        playerTwoRandomNumber = Random.Range(0, playerTwoTotal);

        for (int i = 0; i < playerTwoLoot.lootTable.Length; i++)
        {
            if (playerTwoRandomNumber <= playerTwoLoot.lootTable[i])
            {
                //instantiate corresponding GameObject here.

                Debug.Log("You recieved :" + drops[i].name);
                Instantiate(drops[i], transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }
            else
            {
                playerTwoRandomNumber -= playerTwoLoot.lootTable[i];
            }
        }
    }

}
