
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

    private PlayerInput playerControls;
    private PlayerGeneral playerStats;


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

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            healthDrop = collision.GetComponent<HealthDrop>();
            playerControls.actions["Interact"].performed += ctx => Heal(GetComponent<PlayerGeneral>());
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

}
