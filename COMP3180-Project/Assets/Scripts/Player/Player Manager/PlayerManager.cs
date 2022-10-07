using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Spawn Points
    [Header("Player Spawn Points")]
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;

    //Player Attribute References
    PlayerGeneral playerOneAttributes;
    PlayerGeneral playerTwoAttributes;

    //Player Prefabs
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    private void Awake()
    {
        playerOneAttributes = playerOnePrefab.GetComponent<PlayerGeneral>();
        playerTwoAttributes = playerTwoPrefab.GetComponent<PlayerGeneral>();
    }

    private void Update()
    {
        //
        if(GetComponent<PlayerInputManager>().playerCount > 0)
        {
            GetComponent<PlayerInputManager>().playerPrefab = playerTwoPrefab;
        }
        AttributeComparison();
    }

    void AttributeComparison()
    {
        if (playerOneAttributes.health > playerTwoAttributes.health)
        {
            playerTwoAttributes.greenDropRate = 50f;
        }
    }

}
