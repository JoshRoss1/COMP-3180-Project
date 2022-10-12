using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet Characteristics
    public float damage = 1f;
    public float speed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerGeneral>().health -= damage;
        }*/
    }
}
