using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDA : MonoBehaviour
{
    public PlayerGeneral player;
    public Player1LootDrops player1loot;
    public Player2LootDrops player2loot;

    public int[] defaultTable =
    {
        25,
        22,
        16,
        12,
        8,
        7,
        4,
        3,
        2
    };

    public int[] DDATable =
    {
        2, //Health Drop 
        3, //Shotgun Laser 
        4, //Assault Rifle 
        7, //Plasma Sniper 
        9, //Assaul Laser 
        12, //Plasma Machine Gun 
        16, //Flamethrower 
        22, //Electric Gun 
        25 //Rocket Launcher 
    };

    public int[] HealthTable =
    {
        45, //Health Drop 
        15, //Shotgun Laser 
        10, //Assault Rifle 
        8, //Plasma Sniper 
        7, //Assaul Laser 
        6, //Plasma Machine Gun 
        4, //Flamethrower 
        3, //Electric Gun 
        2 //Rocket Launcher 
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Player 1 current loot table: " + player1loot.lootTable);
        Debug.Log("Player 2 current loot table: " + player2loot.lootTable);

        if (player.player1Score > player.player2Score + 5)
        {
            DDAEnableP2();
            
        }

        if (player.player2Score > player.player1Score + 5)
        {
            DDAEnableP1();
        }

        if (player.health < 30)
        {
            player1loot.lootTable = HealthTable;
        } else
        {
            player1loot.lootTable = defaultTable;
        }

        if (player.health < 30)
        {
            player2loot.lootTable = HealthTable;
        } else
        {
            player2loot.lootTable = defaultTable;
        }
    }

    void DDAEnableP1()
    {
        player1loot.lootTable = DDATable;
        Debug.Log("Player1 DDA Enabled");
    }

    void DDAEnableP2()
    {
        player2loot.lootTable = DDATable;
        Debug.Log("Player2 DDA Enabled");
    }
}
