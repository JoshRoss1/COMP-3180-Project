using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwap2 : MonoBehaviour
{
    public PlayerInput playerControls;

    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = transform.GetChild(0).gameObject;
    }

    void ItemPickup(GameObject newItem)
    {
        GameObject newPrefab = newItem.GetComponent<WeaponPrefabChange>().fullWeaponPrefab;

        if(newItem.CompareTag("Weapon"))
        {
            Destroy(currentWeapon);
            GameObject newWeapon = Instantiate(newPrefab, this.transform.position, Quaternion.identity);
            Destroy(newItem);
            newWeapon.transform.parent = this.transform;
            currentWeapon = newWeapon;
            currentWeapon.GetComponent<BoxCollider2D>().enabled = false;
        }
        Debug.Log(currentWeapon);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerControls.actions["Interact"].performed += ctx => ItemPickup(collision.gameObject);
            Debug.Log("Collision object: " + collision.gameObject.name);
        } else
        {
            Debug.Log("Can't pick up!");
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
