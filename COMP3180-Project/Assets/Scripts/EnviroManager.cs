using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{

    public GameObject spawnObject;
    public Transform[] spawnPoints;
    private crateControl crate;

    public int crateCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnObject, spawnPoints[1].position, Quaternion.identity);
        Instantiate(spawnObject, spawnPoints[9].position, Quaternion.identity);
        Instantiate(spawnObject, spawnPoints[6].position, Quaternion.identity);
        Debug.Log(crateCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void crateSpawn()
    {
        if (crateCount < 3)
        {
            int randomSpawn = Random.Range(0, 9);
            if (Vector2.Distance(spawnPoints[randomSpawn].position, spawnObject.transform.position) < 1f)
            {

            }
            else
            {
            Instantiate(spawnObject, spawnPoints[randomSpawn].position, Quaternion.identity);
            crateCount++;
            }
        }
    }

}
