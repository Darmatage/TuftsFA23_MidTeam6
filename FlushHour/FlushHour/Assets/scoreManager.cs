using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public static scoreManager instance;

    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = (gameControl.control.totalCleaned).ToString();
    }

    public void AddPoint()
    {
        scoreText.text = (gameControl.control.totalCleaned).ToString();
    }
    
}
