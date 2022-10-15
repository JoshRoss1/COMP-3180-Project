using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Player References
    public PlayerInput playerControls;
    public GameObject playerManager;

    //Shooting References
    public GameObject bulletPrefab;
    private GameObject firingPoint;

    //Aim Direction
    public float offset = 1f;
    private Vector2 direction;
    private Vector2 lookPosition;

    //Player Sprite References
    private GameObject playerHead;
    private GameObject playerBody;
    private GameObject playerLegLeft;
    private GameObject playerLegRight;

    private void Awake()
    {
        

        //Find Body Part Game Objects
        playerHead = GameObject.Find("Head");
        playerBody = GameObject.Find("Body");
        playerLegLeft = GameObject.Find("LeftLeg");
        playerLegRight = GameObject.Find("RightLeg");
        playerControls.actions["Shoot"].performed += ctx => Shoot();


    }

    private void Start()
    {
        //Find Firing Point
        firingPoint = gameObject.transform.GetChild(0).gameObject; //Update Projection Point
    }

    // Update is called once per frame
    void Update()
    {
        DirectionalAim();

    }

    private void Shoot()
    {
        Vector2 dirNormalised = lookPosition.normalized;

        //Spawning Bullet
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.transform.position, Quaternion.identity);
        float speed = bullet.GetComponent<Bullet>().speed;
        bullet.GetComponent<Rigidbody2D>().AddForce(dirNormalised * speed, ForceMode2D.Impulse);
    }

    private void DirectionalAim()
    {
        

        playerControls.actions["Aim"].performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
        direction = new Vector2(lookPosition.x - transform.localPosition.x, lookPosition.y - transform.localPosition.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 80 * Time.deltaTime);

        //Sprite Flip
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = true;
            playerBody.GetComponent<SpriteRenderer>().flipX = true;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = true;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<SpriteRenderer>().flipY = true;

        }
        else
        {
            playerHead.GetComponent<SpriteRenderer>().flipX = false;
            playerBody.GetComponent<SpriteRenderer>().flipX = false;
            playerLegLeft.GetComponent<SpriteRenderer>().flipX = false;
            playerLegRight.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<SpriteRenderer>().flipY = false;
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