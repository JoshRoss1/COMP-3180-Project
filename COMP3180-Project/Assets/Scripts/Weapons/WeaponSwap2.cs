using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwap2 : MonoBehaviour
{
    [SerializeField]
    private PlayerInput weaponSwapPlayerControls;

    public GameObject currentWeapon;
    private GameObject gunSpawnPos;

    private GameObject collisionObject;


    private void Awake()
    {
        weaponSwapPlayerControls = transform.root.GetComponent<PlayerInput>();
        gunSpawnPos = this.gameObject;
    }

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
            
            GameObject newWeapon = Instantiate(newPrefab, gunSpawnPos.transform.position, Quaternion.identity);
            newWeapon.transform.parent = transform;
            Destroy(currentWeapon);
            currentWeapon = newWeapon;
            Destroy(newItem);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
        if (collision.gameObject.layer == 6)
        {
            weaponSwapPlayerControls.actions["Interact"].performed += ctx => ItemPickup(collisionObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionObject = null;
    }

    private void OnEnable()
    {
        weaponSwapPlayerControls.actions.Enable();
    }

    private void OnDisable()
    {
        weaponSwapPlayerControls.actions.Disable();
    }
}
