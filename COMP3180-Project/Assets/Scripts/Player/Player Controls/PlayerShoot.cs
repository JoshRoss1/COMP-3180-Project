using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Player References
    PlayerInput playerControls;
    public GameObject playerManager;

    //Shooting References
    public GameObject bulletPrefab;

    //Aim Direction
    public float offset = 1f;
    public GameObject pivotPoint;
    private Vector2 direction;

    private void Awake()
    {
        playerControls = GetComponentInParent<PlayerInput>();

        playerControls.actions["Aim"].performed += ctx => direction = ctx.ReadValue<Vector2>();
        playerControls.actions["Shoot"].performed += ctx => Shoot();

    }

    // Update is called once per frame
    void Update()
    {
        
        

        DirectionalAim();
    }

    private void Shoot()
    {
        Vector2 dirNormalised = direction.normalized;

        //Spawning Bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        float speed = bullet.GetComponent<Bullet>().speed;
        bullet.GetComponent<Rigidbody2D>().AddForce(dirNormalised * speed, ForceMode2D.Impulse);
    }

    private void DirectionalAim()
    {
        direction = new Vector2(direction.x - pivotPoint.transform.localPosition.x, direction.y - pivotPoint.transform.localPosition.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 80 * Time.deltaTime);
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
