using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class Timer : MonoBehaviour {

    //Object variables
    public GameObject timeText;
    public GameObject gameOverText;
    public GameObject scoreText;
    public int startTime = 0;
    public int endTime = 20;
    private float startTimer = 0f;
    private float displayTime = 5.0f;
    private float score = 0;

    void Start(){
        gameOverText.SetActive(false);
        scoreText.SetActive(false);
        score = 0;
        UpdateTime();
    }

    void FixedUpdate()
    {
        startTimer += 0.01f;
        if (startTimer >= 1f)
        {
            startTime += 1;
            startTimer = 0;
            UpdateTime();
        }
        if (startTime >= endTime)
        {
            startTime = endTime;

            StartCoroutine(DisplayGameOver());


        }
    }
    private IEnumerator DisplayGameOver()
    {
        // Display the game object
        score = gameControl.control.totalCleaned;
        UpdateScore();
        gameOverText.SetActive(true);
        scoreText.SetActive(true);

        // Wait for the specified display time
        yield return new WaitForSeconds(displayTime);

        // Hide the game object
        gameOverText.SetActive(false);
        scoreText.SetActive(false);
        SceneManager.LoadScene("MainMenu");

        // You can perform any additional cleanup or actions here

        // Coroutine is finished
    }

    void spawnNPCs(){
            if (startTime < 0){
                //   Instantiate(NPCPrefab, spawnPoint.position, Quaternion.identity);
            }
    }

    public void UpdateTime(){
        Text timeTextB = timeText.GetComponent<Text>();
        timeTextB.text = "" + startTime;
    }
    public void UpdateScore()
{
    Text scoreTextt = scoreText.GetComponent<Text>();
    scoreTextt.text = "Score: " + score.ToString();
}
}