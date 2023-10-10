using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShidderMove : MonoBehaviour
{
    public float moveSpeed;
    public float topSpeed = 0.05f;
    public GameObject shid;
    private Vector3 spawn1 = new Vector3(-7.5f, -4, 0);
    private Vector3 spawn2 = new Vector3(6f, -4, 0);
    private int rand_int;

    private Vector3 exit;
    private Vector3 new_pos;

    private Vector2[] vectorArray;

    private bool reachedPoint = false;
    //public Vector2 offsetFollow;


    void Start()
    {
        moveSpeed = Random.Range((topSpeed * 0.7f), topSpeed);
        //Create a random variable to move to different locations
        rand_int = Random.Range(0, 80);
        int rand_exit = Random.Range(0, 1);
        if (rand_exit == 1)
        {
            exit = spawn1;
        }
        else
        {
            exit = spawn2;
        }

        vectorArray = new Vector2[80];


        //toilets
        vectorArray[0] = new Vector2(-8f, 4f);
        vectorArray[1] = new Vector2(-7.2f, 4f);
        vectorArray[2] = new Vector2(-6.3f, 4f);
        vectorArray[3] = new Vector2(-6.3f, 3.3f);

        vectorArray[4] = new Vector2(-4.7f, 3.3f);
        vectorArray[5] = new Vector2(-4.7f, 4f);

        vectorArray[6] = new Vector2(-8f, 2.4f);
        vectorArray[7] = new Vector2(-7.2f, 2.4f);

        vectorArray[8] = new Vector2(-8f, 0.8f);
        vectorArray[9] = new Vector2(-7.2f, 0.8f);

        vectorArray[10] = new Vector2(-8f, -0.8f);
        vectorArray[11] = new Vector2(-7.2f, -0.8f);

        //urinals
        vectorArray[12] = new Vector2(3f, 4f);
        vectorArray[13] = new Vector2(3f, 3.3f);
        vectorArray[14] = new Vector2(3f, 2.5f);
        vectorArray[15] = new Vector2(3f, 1.7f);

        vectorArray[16] = new Vector2(2f, 4f);
        vectorArray[17] = new Vector2(2f, 3.3f);
        vectorArray[18] = new Vector2(2f, 2.5f);
        vectorArray[19] = new Vector2(2f, 1.7f);

        vectorArray[20] = new Vector2(0.4f, 4f);
        vectorArray[21] = new Vector2(0.4f, 3.3f);
        vectorArray[22] = new Vector2(0.4f, 2.5f);
        vectorArray[23] = new Vector2(0.4f, 1.7f);

        vectorArray[24] = new Vector2(-0.5f, 4f);
        vectorArray[25] = new Vector2(-0.5f, 3.3f);
        vectorArray[26] = new Vector2(-0.5f, 2.5f);
        vectorArray[27] = new Vector2(-0.5f, 1.7f);

        vectorArray[28] = new Vector2(-2f, 4f);
        vectorArray[29] = new Vector2(-2f, 3.3f);
        vectorArray[30] = new Vector2(-2f, 2.5f);
        vectorArray[31] = new Vector2(-2f, 1.7f);

        vectorArray[32] = new Vector2(-3f, 4f);
        vectorArray[33] = new Vector2(-3f, 3.3f);
        vectorArray[34] = new Vector2(-3f, 2.5f);
        vectorArray[35] = new Vector2(-3f, 1.7f);

        //showers
        vectorArray[36] = new Vector2(4.6f, 1.6f);
        vectorArray[37] = new Vector2(5.5f, 1.6f);
        vectorArray[38] = new Vector2(6.3f, 1.6f);
        vectorArray[39] = new Vector2(7.2f, 1.6f);
        vectorArray[40] = new Vector2(8f, 1.6f);

        vectorArray[41] = new Vector2(6.3f, 0.8f);
        vectorArray[42] = new Vector2(7.2f, 0.8f);
        vectorArray[43] = new Vector2(8f, 0.8f);

        vectorArray[44] = new Vector2(4.6f, 2.5f);
        vectorArray[45] = new Vector2(5.5f, 2.5f);

        vectorArray[46] = new Vector2(4.6f, 3.3f);
        vectorArray[47] = new Vector2(5.5f, 3.3f);
        vectorArray[48] = new Vector2(6.3f, 3.3f);
        vectorArray[49] = new Vector2(7.2f, 3.3f);
        vectorArray[50] = new Vector2(8f, 3.3f);

        vectorArray[51] = new Vector2(4.6f, 4.1f);
        vectorArray[52] = new Vector2(5.5f, 4.1f);
        vectorArray[53] = new Vector2(6.3f, 4.1f);
        vectorArray[54] = new Vector2(7.2f, 4.1f);
        vectorArray[55] = new Vector2(8f, 4.1f);

        //sinks
        vectorArray[56] = new Vector2(-3f, -0.8f);
        vectorArray[57] = new Vector2(-2f, -0.8f);
        vectorArray[58] = new Vector2(-1.3f, -0.8f);
        vectorArray[59] = new Vector2(-0.5f, -0.8f);
        vectorArray[60] = new Vector2(0.4f, -0.8f);
        vectorArray[61] = new Vector2(1.2f, -0.8f);
        vectorArray[62] = new Vector2(2f, -0.8f);
        vectorArray[63] = new Vector2(3f, -0.8f);

        vectorArray[64] = new Vector2(-3f, -2.5f);
        vectorArray[65] = new Vector2(-2f, -2.5f);
        vectorArray[66] = new Vector2(-1.3f, -2.5f);
        vectorArray[67] = new Vector2(-0.5f, -2.5f);
        vectorArray[68] = new Vector2(0.4f, -2.5f);
        vectorArray[69] = new Vector2(1.2f, -2.5f);
        vectorArray[70] = new Vector2(2f, -2.5f);
        vectorArray[71] = new Vector2(3f, -2.5f);

        vectorArray[72] = new Vector2(-3f, -4f);
        vectorArray[73] = new Vector2(-2f, -4f);
        vectorArray[74] = new Vector2(-1.3f, -4f);
        vectorArray[75] = new Vector2(-0.5f, -4f);
        vectorArray[76] = new Vector2(0.4f, -4f);
        vectorArray[77] = new Vector2(1.2f, -4f);
        vectorArray[78] = new Vector2(2f, -4f);
        vectorArray[79] = new Vector2(3f, -4f);

        new_pos = vectorArray[rand_int];

    }

    void Update()
    {
        if (!reachedPoint)
        {
            moveToLocation();
            if (transform.position == new_pos)
            {
                reachedPoint = true;
                Invoke("dropShid", 0.5f);
            }
        }
        else if (reachedPoint)
        {
            Invoke("leaveBathroom", 1);
            if (transform.position == exit)
            {
                DestroyShidder();
            }
        }
        
        
    }

    void moveToLocation()
    {
        transform.position = Vector2.MoveTowards(transform.position, new_pos, moveSpeed);
    }

    void leaveBathroom()
    {
        transform.position = Vector2.MoveTowards(transform.position, exit, moveSpeed);              
    }

    void DestroyShidder()
    {
        Destroy(gameObject);
    }

    void dropShid()
    {
        Instantiate(shid, transform.position, Quaternion.identity);
    }
    

    IEnumerator Example()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log("Released" + Time.time);
    }
}