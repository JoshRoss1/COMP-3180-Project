using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerTwoPrefab;
    private Gamepad player1;

    private void Update()
    {
        InputSystem.onDeviceChange +=
            (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Added:
                        Debug.Log("Device Added: " + device.device.displayName);
                        player1 = device.device as Gamepad;
                        break;
                    case InputDeviceChange.Removed:
                        Debug.Log("Device Removed: " + device.device.displayName);
                        break;
                    default: break;
                }
            };
    }

    public void UpdatePrefabForNextPlayer()
    {
        GetComponent<PlayerInputManager>().playerPrefab = playerTwoPrefab;
        PlayerInput.Instantiate(playerTwoPrefab, pairWithDevice: player1);
    }
}
