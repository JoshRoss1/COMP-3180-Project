using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Prefabs")]
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    [Header("Player Spawn Points")]
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;

    private Gamepad player1;
    private Gamepad player2;

    private void Awake()
    {
        InputSystem.onDeviceChange +=
            (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Added:
                        Debug.Log("Device Added: " + device.device.deviceId);
                        player1 = Gamepad.all[0];
                        player2 = Gamepad.all[1];
                        break;
                    case InputDeviceChange.Removed:
                        Debug.Log("Device Removed: " + device.device.deviceId);
                        break;
                    default: break;
                }
            };
    }

    private void Start()
    {
        PlayerInput playerOne = PlayerInput.Instantiate(playerOnePrefab, pairWithDevice: player1);
        playerOne.transform.position = playerOneSpawn.transform.position;

        PlayerInput playerTwo = PlayerInput.Instantiate(playerTwoPrefab, pairWithDevice: player2);
        playerTwo.transform.position = playerTwoSpawn.transform.position;
    }

    private void Update()
    {
        
    }
}
