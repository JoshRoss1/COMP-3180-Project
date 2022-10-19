using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public Scorekeeper scores;

    public Text p1score;
    public Text p2score;

    public Transform p1;
    public Transform p2;

    public GameObject Player1;
    public GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUpdate();
        Instantiate(Player1, p1.position, Quaternion.identity);
        Instantiate(Player2, p2.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ScoreUpdate()
    {
        p1score.text = "Kills: " + scores.currentscorep1;
        p2score.text = "Kills: " + scores.currentscorep2;
    }
}
