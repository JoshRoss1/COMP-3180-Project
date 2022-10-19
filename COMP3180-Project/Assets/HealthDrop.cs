using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthDrop : MonoBehaviour
{
    public float healAmount = 0f;
    PlayerGeneral playerStats;
    PlayerInput playerControls = null;

    private void Awake()
    {
        
    }

    private void Update()
    {

    }


    

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision = null;
    }

    
}
