using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shid : MonoBehaviour
{
    // The sound effect to play when picked up
    public AudioClip pickupSound;

    // The reference to the AudioSource component
    public AudioSource audioSource;

    // The reference to the coroutine
    private Coroutine pickupCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // This function is called when another collider enters this collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Start the pickup coroutine
            pickupCoroutine = StartCoroutine(Pickup());
        }
    }

    // This function is called when another collider exits this collider
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Stop the pickup coroutine if it is running
            if (pickupCoroutine != null)
            {
                StopCoroutine(pickupCoroutine);
                pickupCoroutine = null;
            }
        }
    }

    // This function is a coroutine that handles the pickup logic
    IEnumerator Pickup()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(2f);

        // Play the pickup sound
        //audioSource.PlayOneShot(pickupSound);

        // Destroy this item after a delay (to allow the sound to finish playing)
        Destroy(gameObject, pickupSound.length);
    }
}
