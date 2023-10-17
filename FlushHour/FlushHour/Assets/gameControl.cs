using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControl : MonoBehaviour
{

    public static gameControl control;

    public int score;

    private void Awake()
    {
        //if a control already, delete

        //If none, make this the control
        if (control == null) {
            control = this; 
            DontDestroyOnLoad(gameObject);
        } else if (control != this) {
            Destroy(gameObject);
        }

    }

}
