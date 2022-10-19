using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{

    public PlayerGeneral pg;
    public PlayerGeneral pg2;
    public Text player1text;
    public Text player2text;

    public int currentscorep1 = 9;
    public int currentscorep2 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scoreUpdate()
    {
        if (pg.player1died)
        {
            player1text.text += 1;
            currentscorep1++;
        }

        if (pg2.player2died)
        {
            player2text.text += 1;
            currentscorep2++;
        }
    }
}
