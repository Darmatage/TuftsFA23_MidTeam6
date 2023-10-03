using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShidderMove : MonoBehaviour
{
    //this script offers basic flocking behavior for friendly NPCs to follow the player
    //commented-out are functions for followers to help attack enemies if the player attacks

    //private Animator anim;

    //Follow Player
    private GameObject player;
    private Vector2 playerPos;
    private float distToPlayer;
    public float moveSpeed;
    public float topSpeed = 0.05f;
    private float scaleX;
    private int rand_int;
    //public Vector2 offsetFollow;

    //Follow Player vs Attack Enemies
    public bool followPlayer = true;

    void Start()
    {
        //anim = gameObject.GetComponentInChildren<Animator>();
        moveSpeed = Random.Range((topSpeed * 0.7f), topSpeed);
        scaleX = gameObject.transform.localScale.x;
        rand_int = Random.Range(0, 4);
    }

    void Update()
    {
        //Move to location
        Vector2[] vector_arr = new Vector2[4];
        
        Debug.Log("Int: " + rand_int);
        //toilets
        vector_arr[0] = new Vector2(-8f, 4f);
        //urinals
        vector_arr[1] = new Vector2(0f, 4f);
        //showers
        vector_arr[2] = new Vector2(8f, 4f);
        //sinks
        vector_arr[3] = new Vector2(0f, 0f);


        transform.position = Vector2.MoveTowards(transform.position, vector_arr[rand_int], moveSpeed);
        //Create a random variable to move to different locations

    }

    //void FixedUpdate()
    //{
    //    //FOLLOW PLAYER
    //    if ((followPlayer) && (player != null))
    //    {
    //        playerPos = player.transform.position;
    //        distToPlayer = Vector2.Distance(transform.position, playerPos);

    //        //Retreat from Player
    //        if (distToPlayer <= followDistance)
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, playerPos, -moveSpeed * Time.deltaTime);
    //            //anim.SetBool("Walk", true);
    //        }

    //        // Stop following Player
    //        if ((distToPlayer > followDistance) && (distToPlayer < startFollowDistance))
    //        {
    //            transform.position = this.transform.position;
    //            //anim.SetBool("Walk", false);
    //        }

    //        // Follow Player
    //        else if (distToPlayer >= startFollowDistance)
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
    //            //anim.SetBool("Walk", true);
    //        }

    //        // Turn follower toward player (good for bipedal characters)
    //        /*
    //         if (player.transform.position.x > gameObject.transform.position.x){
    //                  gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
    //          } else {
    //                  gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
    //          }
    //          */

    //        // Rotate to face player (good for swimming / flying followers)
    //        Vector2 direction = (playerPos - (Vector2)transform.position).normalized;
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        float offset = 90f;
    //        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    //    }
    //}
}