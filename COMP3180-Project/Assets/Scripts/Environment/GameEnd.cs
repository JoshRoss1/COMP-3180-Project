using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    void EndGame()
    {
        if (timer.timerIsRunning == false)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
