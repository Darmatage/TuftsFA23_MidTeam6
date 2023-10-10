using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShidderSpawner : MonoBehaviour
{

    //Object variables
    public GameObject shidderPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    private Transform spawnPoint;

    //Timing variables
    public float spawnRangeStart = 0.5f;
    public float spawnRangeEnd = 1.2f;
    private float timeToSpawn;
    private float spawnTimer = 0f;

    void FixedUpdate()
    {
        timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
        spawnTimer += 0.01f;
        if (spawnTimer >= timeToSpawn)
        {
            spawnShidder();
            spawnTimer = 0f;
        }
    }

    void spawnShidder()
    {
        int SPnum = Random.Range(1, 3);
        if (SPnum == 1) { spawnPoint = spawnPoint1; }
        else if (SPnum == 2) { spawnPoint = spawnPoint2; }
        Instantiate(shidderPrefab, spawnPoint.position, Quaternion.identity);
    }
}