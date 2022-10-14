
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGeneral : MonoBehaviour
{
    public float health = 100f;

    private PlayerInput playerControls;


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

    void ItemPickup(GameObject newItem)
    {
        Debug.Log("Interacting with: " + newItem.gameObject.name);
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("WeaponSlot"))
            {
                
                for (int j = 0; j < transform.GetChild(i).childCount; j++)
                {
                    
                    if (!(transform.GetChild(i).GetChild(j).tag == newItem.tag))
                    {
                        transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                        transform.GetChild(i).GetChild(j).gameObject.layer = 6;
                    } else
                    {
                        transform.GetChild(i).GetChild(j).gameObject.SetActive(true);
                        transform.GetChild(i).GetChild(j).gameObject.layer = 7;
                        Debug.Log("Active Gun: " + transform.GetChild(i).GetChild(j).gameObject.name);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerControls.actions["Interact"].performed += ctx => ItemPickup(collision.gameObject);
            Debug.Log("Collision object: " + collision.gameObject.name);
        }
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
