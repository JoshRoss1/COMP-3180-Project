using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet Characteristics
    public float damage = 0f;
    public float speed = 1f;

    private string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Obstacle":
                Destroy(gameObject);
                break;
            case "Hitbox":
                Destroy(gameObject);
                collision.gameObject.GetComponentInParent<PlayerGeneral>().health -= damage;
                Debug.Log(collision.gameObject.name);
                break;
            case null:
                break;
        }
    }
}
