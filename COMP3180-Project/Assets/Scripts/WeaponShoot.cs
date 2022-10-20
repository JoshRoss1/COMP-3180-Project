using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private PlayerInput playerControllerInput;
    private Transform firingPoint;


    //Shooting and Aiming Variables
    private GameObject weapon;
    private Vector2 direction;
    [HideInInspector]
    public Vector2 lookPosition;

    

    // Start is called before the first frame update
    void Start()
    {

        playerControllerInput = transform.root.GetComponent<PlayerInput>();
        weapon = this.gameObject;
    }

    private void Update()
    {
        DirectionalAim();
        firingPoint = transform.GetChild(0).gameObject.transform;
        playerControllerInput.actions["Shoot"].performed += ctx => Shoot(firingPoint.transform);
    }

    private void Shoot(Transform bulletSpawn)
    {

        //Spawning Bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        float speed = bullet.GetComponent<Bullet>().speed;
        bullet.GetComponent<Rigidbody2D>().AddForce(lookPosition.normalized * speed, ForceMode2D.Impulse);
    }

    private void DirectionalAim()
    {
        playerControllerInput.actions["Aim"].performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
        direction = new Vector2(lookPosition.x - transform.localPosition.x, lookPosition.y - transform.localPosition.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 80 * Time.deltaTime);      
    }

    public Quaternion GetGunRotation()
    {
        return transform.rotation;
    }

    public GameObject GetWeapon()
    {
        return weapon;
    }
}
