using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShidderSpawner : MonoBehaviour
{

    //Object variables
    public GameObject shidderPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    //private int time = 0;
    private Transform spawnPoint;

    public GameObject timerScript1;
    private Timer timerVar;

    //Timing variables
    public float spawnRangeStart = 1f;
    public float spawnRangeEnd = 6f;
    private float timeToSpawn;
    private float spawnTimer = 0f;
    private float newRangeEnd;

    void Start()
    {
        timerVar = timerScript1.GetComponent <Timer> ();
        newRangeEnd = spawnRangeEnd;
    }

    void FixedUpdate()
    {
        createNewRangeEnd();

        timeToSpawn = Random.Range(spawnRangeStart, newRangeEnd);
        spawnTimer += 0.01f;
        if (spawnTimer >= timeToSpawn)
        {
            spawnShidder();
            spawnTimer = 0f;
        }
    }

    void createNewRangeEnd()
    {
        int time = timerVar.startTime;

        if (time > 0 && time % 10 == 0)
        {
            newRangeEnd = spawnRangeEnd - ((spawnRangeEnd*time/10*1.7f) / 10);

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