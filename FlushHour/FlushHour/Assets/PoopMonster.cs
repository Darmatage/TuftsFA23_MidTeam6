using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopMonster : MonoBehaviour
{
    // The reference to the coroutine
    private Coroutine cleanupCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.3f);
    }
}
