using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crateControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen = false;

    PlayerInput playerControls;

    private void Awake()
    {
        playerControls = GetComponentInParent<PlayerInput>();
    }

    void Start()
    {
        spriteRenderer.sprite = closedSprite;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerControls.actions["Interact"].triggered)
            {
                spriteRenderer.sprite = openSprite;
                isOpen = true;
            }
        }
    }
}
