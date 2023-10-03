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
    public int gameTime = 20;
    private float gameTimer = 0f;
    private float displayTime = 3.0f;

    void Start(){
        gameOverText.SetActive(false);
        UpdateTime();
    }

    void FixedUpdate()
    {
        gameTimer += 0.01f;
        if (gameTimer >= 1f)
        {
            gameTime -= 1;
            gameTimer = 0;
            UpdateTime();
        }
        if (gameTime <= 0)
        {
            gameTime = 0;
            StartCoroutine(DisplayGameOver());


        }
    }
    private IEnumerator DisplayGameOver()
    {
        // Display the game object
        gameOverText.SetActive(true);
        // Wait for the specified display time
        yield return new WaitForSeconds(displayTime);

        // Hide the game object
        gameOverText.SetActive(false);
        SceneManager.LoadScene("MainMenu");

        // You can perform any additional cleanup or actions here

        // Coroutine is finished
    }

    void spawnNPCs(){
            if (gameTime > 0){
                //   Instantiate(NPCPrefab, spawnPoint.position, Quaternion.identity);
            }
    }

    public void UpdateTime(){
        Text timeTextB = timeText.GetComponent<Text>();
        timeTextB.text = "" + gameTime;
    }
}