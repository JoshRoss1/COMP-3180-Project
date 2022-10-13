using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TerminalController : MonoBehaviour
{

    PlayerInput playerControls;

    public GameObject spawnPoint;
    public GameObject laser;


    private void Awake()
    {
        playerControls = GetComponentInParent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            playerControls.actions["Interact"].performed += ctx => SpawnLaser();
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            playerControls.actions["Interact"].performed += ctx => SpawnLaser();
        }
    }

    void SpawnLaser()
    {

        Instantiate(laser, spawnPoint.transform.position, Quaternion.identity);
       
    }

}
