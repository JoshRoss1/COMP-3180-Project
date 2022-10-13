
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
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "WeaponSlot")
            {
                Instantiate(newItem, transform.GetChild(i));            //Spawn gun that was picked up in hand
                Destroy(transform.GetChild(i).GetChild(0).gameObject);  //Destroy gun in hand
                Destroy(newItem);                                       //Destroy gun that was picked up
                Debug.Log(i);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            playerControls.actions["Interact"].performed += ctx => ItemPickup(collision.gameObject);
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
