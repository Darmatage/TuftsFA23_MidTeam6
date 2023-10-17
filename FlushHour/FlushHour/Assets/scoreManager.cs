using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public static scoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = (gameControl.control.totalCleaned).ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        scoreText.text = (gameControl.control.totalCleaned).ToString();
    }
    
}
