using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private PlayerInput playerControllerInput;
    public GameObject firingPoint;


    //Shooting and Aiming Variables
    private GameObject weapon;
    private Vector2 direction;
    [HideInInspector]
    public Vector2 lookPosition;


    // Start is called before the first frame update
    void Awake()
    {

        
        
    }

    private void Update()
    {
        playerControllerInput = transform.root.GetComponent<PlayerInput>();

            DirectionalAim();

        playerControllerInput.actions["Shoot"].performed += ctx => Shoot();
    }

    private void Shoot()
    {
        //THIS WILL GO INTO A SCRIPT ONTO THE GUNS
        Vector2 dirNormalised = lookPosition.normalized;

        //Spawning Bullet
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.transform.position, Quaternion.identity);
        float speed = bullet.GetComponent<Bullet>().speed;
        bullet.GetComponent<Rigidbody2D>().AddForce(dirNormalised * speed, ForceMode2D.Impulse);
    }

    private void DirectionalAim()
    {
        playerControllerInput.actions["Aim"].performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
        direction = new Vector2(lookPosition.x - transform.localPosition.x, lookPosition.y - transform.localPosition.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 80 * Time.deltaTime);

        //Sprite Flip
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            /*playerHead.GetComponent<SpriteRenderer>().flipX = true;
            playerBody.GetComponent<SpriteRenderer>().flipX = true;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = true;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<SpriteRenderer>().flipY = true;*/

        }
        else
        {
            /*playerHead.GetComponent<SpriteRenderer>().flipX = false;
            playerBody.GetComponent<SpriteRenderer>().flipX = false;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = false;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<SpriteRenderer>().flipY = false;*/
        }
    }
}
