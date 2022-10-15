using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwap : MonoBehaviour
{
    /*
        Credit to The Game Guy on Youtube for a few pointers on how to figure this out. Original video can be found here:
        https://www.youtube.com/watch?v=-YISSX16NwE&ab_channel=TheGameGuy. 
     */


    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponSlot;
    public GameObject currentWeapon;

    public PlayerInput playerControls;

    // Start is called before the first frame update
    void Start()
    {
        

        totalWeapons = weaponSlot.transform.childCount;
        guns = new GameObject[totalWeapons];

        for(int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponSlot.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
            guns[i].transform.GetChild(0).gameObject.SetActive(false);
        }

        guns[0].SetActive(true);
        guns[0].transform.GetChild(0).gameObject.SetActive(false);
        currentWeapon = guns[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerControls.actions["Interact"].performed += ctx => ItemPickup(collision.gameObject);
            Debug.Log("Collision object: " + collision.gameObject.name);
        }
    }

    void ItemPickup(GameObject newItem)
    {
        //Loop through gun array to get index of picked up weapon
        for(int i = 0; i < totalWeapons; i++)
        {
            if (newItem.CompareTag(guns[i].tag))
            {
                guns[currentWeaponIndex].SetActive(false);
                guns[currentWeaponIndex].transform.GetChild(0).gameObject.SetActive(false);
                currentWeaponIndex = i;
                guns[currentWeaponIndex].SetActive(true);
                guns[currentWeaponIndex].transform.GetChild(0).gameObject.SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
            }
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
