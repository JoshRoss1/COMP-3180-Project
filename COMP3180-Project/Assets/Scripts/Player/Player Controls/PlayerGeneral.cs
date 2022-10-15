
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGeneral : MonoBehaviour
{
    public float health = 100f;

    private PlayerInput playerControls;


    // Start is called before the first frame update
    void Awake()
    {
        playerControls = GetComponent<PlayerInput>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

}
