
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerGeneral : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    public int playerID;

    //Spawn Point References
    private Transform player1Spawn;
    private Transform player2Spawn;

    //Interactables
    private HealthDrop healthDrop;
    private WeaponSwap2 weaponDrop;

    //Player References
    private PlayerInput playerControls;
    private Player1LootDrops player1Loot;
    private Player2LootDrops player2Loot; 

    //Weapon References
    private WeaponShoot weaponRotation;

    //Sprite References
    public GameObject playerHead;
    public GameObject playerBody;
    public GameObject playerLegLeft;
    public GameObject playerLegRight;

    //Text References
    [HideInInspector]
    public int player1Score = 0;
    [HideInInspector]
    public int player2Score = 0;
    private Text player1Text;
    private Text player2Text;

    //Loot Tables
    public int[] defaultTable =
    {
        25,
        22,
        16,
        12,
        8,
        7,
        4,
        3,
        2
    };

    public int[] DDATable =
    {
        2, //Health Drop 
        3, //Shotgun Laser 
        4, //Assault Rifle 
        7, //Plasma Sniper 
        9, //Assaul Laser 
        12, //Plasma Machine Gun 
        16, //Flamethrower 
        22, //Electric Gun 
        25 //Rocket Launcher 
    };

    public int[] HealthTable =
    {
        45, //Health Drop 
        15, //Shotgun Laser 
        10, //Assault Rifle 
        8, //Plasma Sniper 
        7, //Assaul Laser 
        6, //Plasma Machine Gun 
        4, //Flamethrower 
        3, //Electric Gun 
        2 //Rocket Launcher 
    };



    // Start is called before the first frame update
    void Awake()
    {
        playerControls = GetComponent<PlayerInput>();
        player1Text = GameObject.Find("Player1Score").GetComponent<Text>();
        player2Text = GameObject.Find("Player2Score").GetComponent<Text>();

        player1Spawn = GameObject.Find("Player1Spawn").GetComponent<Transform>();
        player2Spawn = GameObject.Find("Player2Spawn").GetComponent<Transform>();

        
       
        health = maxHealth;
    }

    private void Start()
    {
        if (playerID == 1)
        {
            player1Loot = gameObject.GetComponent<Player1LootDrops>();
        }

        if (playerID == 2)
        {
            player2Loot = gameObject.GetComponent<Player2LootDrops>();
        }
    }



    // Update is called once per frame
    void Update()
    {
        DDA();

        
        //check which player died to calculate score.
        if(health <= 0)
        {
            
            if (playerID == 1)
            {
                Debug.Log("Player 1 Died");
                player2Score++;
                player2Text.text = player2Score.ToString();
                Respawn(1);
            }
            if (playerID == 2)
            {
                player1Score++;
                player1Text.text = player1Score.ToString();
                Respawn(2);
            }
        }

        //Set up Sprite Flip
        weaponRotation = GameObject.Find("Weapon").GetComponentInChildren<WeaponShoot>();
        SpriteFlip(weaponRotation.GetGunRotation());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Health":
                healthDrop = collision.GetComponent<HealthDrop>();
                playerControls.actions["Interact"].performed += ctx => Heal(GetComponent<PlayerGeneral>());
                break;
            case "Weapon":
                weaponDrop = GetComponentInChildren<WeaponSwap2>();
                playerControls.actions["Interact"].performed += ctx => weaponDrop.WeaponPickup(collision.gameObject);
                break;
        }

    }

    void Heal(PlayerGeneral playerStats)
    {
        Debug.Log("Working");
        if ((playerStats.health + healthDrop.healAmount) <= maxHealth)
        {
            playerStats.health += healthDrop.healAmount;
            Destroy(healthDrop.gameObject);
        }

    }

    void SpriteFlip(Quaternion gunRotation)
    {
        GameObject weapon = weaponRotation.GetWeapon();

        //Sprite Flip
        if (gunRotation.eulerAngles.z > 90 && gunRotation.eulerAngles.z < 270)
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = true;
            playerBody.GetComponent<SpriteRenderer>().flipX = true;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = true;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = true;
            weapon.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = false;
            playerBody.GetComponent<SpriteRenderer>().flipX = false;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = false;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = false;
            weapon.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void Respawn(int playerID)
    {
        if(playerID == 1)
        {
            gameObject.transform.position = player1Spawn.position;
            this.health = maxHealth;
        }

        if(playerID == 2)
        {
            gameObject.transform.position = player2Spawn.position;
            this.health = maxHealth;
        }
    }

    void DDA()
    {

        if (player1Score > player2Score + 5)
        {
            DDAEnableP2();
            Debug.Log("Player2 DDA Enabled");
        }

        if (player2Score > player1Score + 5)
        {
            DDAEnableP1();
            Debug.Log("Player1 DDA Enabled");
        }

        if (health < 30 && playerID == 1)
        {
            player1Loot.lootTable = HealthTable;
        }

        if (health < 30 && playerID == 2)
        {
            player2Loot.lootTable = HealthTable;
        }
    }

    void DDAEnableP1()
    {
        player1Loot.lootTable = DDATable;
    }

    void DDAEnableP2()
    {
        player2Loot.lootTable = DDATable;
    }
}
