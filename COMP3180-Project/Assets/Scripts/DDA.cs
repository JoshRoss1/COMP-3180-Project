using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDA : MonoBehaviour
{
    public PlayerGeneral player1;
    public PlayerGeneral player2;
    public Player1LootDrops player1loot;
    public Player2LootDrops player2loot;

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
        //if (player1.player1score > player2.player2score + 5)
        //{
        //    DDAEnableP2();
        //    Debug.Log("Player2 DDA Enabled");
        //}

        //if (player2.player2score > player1.player1score + 5)
        //{
        //    DDAEnableP1();
        //    Debug.Log("Player1 DDA Enabled");
        //}

        if (player1.health < 30)
        {
            player1loot.lootTable = HealthTable;
        }

        if (player2.health < 30)
        {
            player2loot.lootTable = HealthTable;
        }
    }

    void DDAEnableP1()
    {
        player1loot.lootTable = DDATable;
    }

    void DDAEnableP2()
    {
        player2loot.lootTable = DDATable;
    }
}
