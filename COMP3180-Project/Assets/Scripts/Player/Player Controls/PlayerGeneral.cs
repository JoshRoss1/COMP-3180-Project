
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGeneral : MonoBehaviour
{
    public float health = 100f;
    public int playerID;

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



    // Start is called before the first frame update
    void Awake()
    {
        playerControls = GetComponent<PlayerInput>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
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
        if ((playerStats.health + healthDrop.healAmount) <= 100)
        {
            playerStats.health += healthDrop.healAmount;
            Destroy(healthDrop.gameObject);
        }

    }

    void SpriteFlip(Quaternion gunRotation)
    {
        //Sprite Flip
        if (gunRotation.eulerAngles.z > 90 && gunRotation.eulerAngles.z < 270)
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = true;
            playerBody.GetComponent<SpriteRenderer>().flipX = true;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = true;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = false;
            playerBody.GetComponent<SpriteRenderer>().flipX = false;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = false;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

}
