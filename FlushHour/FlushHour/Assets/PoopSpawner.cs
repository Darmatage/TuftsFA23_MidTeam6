
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

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
        else if (spawnTimer > 0.75)
        {
            Debug.Log("lost minigame");
        }
    }

    void spawnPoop()
    {
        int SPnum = Random.Range(0, rangeEnd);
        spawnPoint = spawnPoints[SPnum];
        Instantiate(poopPrefab, spawnPoint.position, Quaternion.identity);
    }
}