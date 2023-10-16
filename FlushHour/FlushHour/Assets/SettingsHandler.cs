using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsHandler : MonoBehaviour
{
    [Header("References")]
    public GameObject menuUI;
    public GameObject[] buttons;

    [Header("Variables")]
    public float tweenTime = 0.2f;
    public static float volumeLevel = 1.0f;

    //Private Extras
    private bool paused;
    private float[] butPositions;
    //Happens at the start of the scene
    void Start()
    {
         Debug.Log("Run Start Function");
        butPositions = new float[3];
        for(int i = 0; i < buttons.Length; i++)
            butPositions[i] = buttons[i].transform.position.y + -150f;
        // logoScale = logo.transform.localScale.z;
        Resume();
    }

    void Update()
    {
         Debug.Log("Run Update Function");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc clicked");
            if(paused){
                Debug.Log("resuming");
                Resume();
            }else
                Pause();
        }
    }
    public void Resume()
    {
         Debug.Log("Run Resume Function");

        Time.timeScale = 1f;
        menuUI.SetActive(false);
        paused = false;
    }

    //Pauses the game
    public void Pause()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        paused = true;
    }

    //Quits the game (both in Unity and when exported)
    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    // public void SetLevel (float sliderValue)
    // {
    //     mixer.SetFloat("Volume", Mathf.Log10 (sliderValue) * 20);
    //     volumeLevel = sliderValue;
    // }
}
