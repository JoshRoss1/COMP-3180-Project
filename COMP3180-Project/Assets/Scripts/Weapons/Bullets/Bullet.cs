using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet Characteristics
    public float damage = 1f;
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
            case "Player":
                Destroy(gameObject);
                collision.gameObject.GetComponent<PlayerGeneral>().health -= damage;
                break;
            case null:
                break;
        }
    }
}
