using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Spawn Points")]
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;

    public GameObject playerTwoPrefab;

    private void Update()
    {
        if(GetComponent<PlayerInputManager>().playerCount > 0)
        {
            GetComponent<PlayerInputManager>().playerPrefab = playerTwoPrefab;
        }
    }

}
