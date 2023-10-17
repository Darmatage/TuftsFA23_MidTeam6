
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PoopSpawner : MonoBehaviour
{

    //Object variables
    public GameObject poopPrefab;
    public Transform[] spawnPoints;
    private int rangeEnd;
    private Transform spawnPoint;

    //Timing variables
    public float spawnRangeStart = 0.2f;
    public float spawnRangeEnd = 0.5f;
    private float timeToSpawn;
    private float spawnTimer = 0f;

    //counting variables
    private int totalPoops = 0;
    private List<GameObject> spawnedMonsters = new List<GameObject>();

    void Start()
    {
        //assign the length of the array to the end of the random range
        rangeEnd = spawnPoints.Length - 1;
    }

    void FixedUpdate()
    {
        timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
        spawnTimer += 0.01f;
        if (spawnTimer >= timeToSpawn && totalPoops < 10)
        {
            spawnPoop();
            spawnTimer = 0f;
            totalPoops++;
        }
        
        if (spawnTimer > 0.75 && AreObjectsRemaining())
        {
            Debug.Log(spawnedMonsters.Count + "You lose");
            SceneManager.LoadScene("GameScene");
        }
        else if (spawnTimer > 0.75 && !AreObjectsRemaining())
        {
            Debug.Log("You win");
            gameControl.control.totalCleaned += 10;
            SceneManager.LoadScene("GameScene");
        }
    }

    void spawnPoop()
    {
        int SPnum = Random.Range(0, rangeEnd);
        spawnPoint = spawnPoints[SPnum];
        GameObject Monster = Instantiate(poopPrefab, spawnPoint.position, Quaternion.identity);
        spawnedMonsters.Add(Monster);
    }

    bool AreObjectsRemaining()
    {
        for (int i = spawnedMonsters.Count - 1; i >= 0; i--)
        {
            if (spawnedMonsters[i] == null)
            {
                spawnedMonsters.RemoveAt(i);
            }
        }

        // If the list is empty, all objects have been destroyed.
        return spawnedMonsters.Count != 0;
    }
}