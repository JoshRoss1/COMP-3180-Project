
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

    //Weapon References
    private WeaponShoot weaponRotation;

    //Sprite References
    public GameObject playerHead;
    public GameObject playerBody;
    public GameObject playerLegLeft;
    public GameObject playerLegRight;

    //Text References
    private int player1Score = 0;
    private int player2Score = 0;
    private Text player1Text;
    private Text player2Text;



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

    

    // Update is called once per frame
    void Update()
    {
        
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
}
