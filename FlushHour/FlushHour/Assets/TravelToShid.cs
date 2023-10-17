using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TravelToShid : MonoBehaviour
{
    public GameObject shid;

    public SpriteRenderer spriteRenderer;
    public Sprite relaxedSprite;

    public Transform target;
    //public Transform spawn1;
    //public Transform spawn2;

    //private GameObject target;
    private GameObject exit;

    private Vector3 targetPosition;
    private Vector3 targetScale;
    private Quaternion targetRotation;

    private Vector3 spawn1Position;
    private Vector3 spawn1Scale;
    private Quaternion spawn1Rotation;

    private Vector3 spawn2Position;
    private Vector3 spawn2Scale;
    private Quaternion spawn2Rotation;

    private Vector3 temp;

    public Sprite[] worried;
    public Sprite[] relaxed;
    private bool reachedPoint = false;
    private bool exiting = false;
    private bool shidded = false;
    private bool faceRight = true;
    //private int randSprite;

    Seeker seeker;
    Path path;

    // Start is called before the first frame update
    void Start()
    {
        instatiateTransforms();
        makeWaypoint();
        seeker = GetComponent<Seeker>();

        randomSprite();

        int rand_exit = Random.Range(0, 2);
        if (rand_exit == 1)
        {
            exit.transform.position = spawn1Position;
            exit.transform.localScale = spawn1Scale;
            exit.transform.rotation = spawn1Rotation;
        }
        else
        {
            exit.transform.position = spawn2Position;
            exit.transform.localScale = spawn2Scale;
            exit.transform.rotation = spawn2Rotation;
        }

        if (!shidded)
        {
            shidded = true;
            StartCoroutine(pathToShid());
        }

    }
    IEnumerator pathToShid()
    {
        temp = target.position;
        path = seeker.StartPath(transform.position, temp, OnPathComplete);
        yield return StartCoroutine(path.WaitForPath());
        

    }

    void instatiateTransforms()
    {
        
        targetPosition = new Vector3(0f, 0f, 0f);
        spawn1Position= new Vector3(-7.5f, -4f, 0f);
        spawn2Position = new Vector3(6f, -4f, 0f);
        

        targetScale = new Vector3(1f, 1f, 1f);
        spawn1Scale = new Vector3(1f, 1f, 1f);
        spawn2Scale = new Vector3(1f, 1f, 1f);

        targetRotation = new Quaternion(0f, 0f, 0f, 0f);
        spawn1Rotation = new Quaternion(0f, 0f, 0f, 0f);
        spawn2Rotation = new Quaternion(0f, 0f, 0f, 0f);

        exit = new GameObject();

        target.position = targetPosition;
        target.localScale = targetScale;
        target.rotation = targetRotation;
    }

    void makeWaypoint()
    {
        Vector2[] vectorArray = new Vector2[80];
        int rand_int = Random.Range(0, 80);

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

        Vector3 randPosition = vectorArray[rand_int];
        target.position += randPosition;
    }

    void randomSprite()
    {
        int randSprite = Random.Range(0, 9);
        spriteRenderer.sprite = worried[randSprite];
        relaxedSprite = relaxed[randSprite];

    }
    void flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedPoint)
        {
            float h = (temp.x - transform.position.x);
            if (h > 0 && !faceRight)
            {
                flip();
            }
            else if (h < 0 && faceRight)
            {
                flip();
            }
        }

        if (Vector3.Distance(transform.position, temp) <= 0.2f && !reachedPoint)
        {
            reachedPoint = true;
            Invoke("dropShid", 1f);            
        }

        if (reachedPoint)
        {
            float h = (exit.transform.position.x - transform.position.x);
            if (h > 0 && !faceRight)
            {
                flip();
            }
            else if (h < 0 && faceRight)
            {
                flip();
            }

            if (!exiting)
            {
                StartCoroutine(standStill()); 
            }

            if (Vector3.Distance(transform.position, exit.transform.position) <=0.1f)
            {
                DestroyShidder();
            }
        }
    }

    IEnumerator pathToExit()
    {
        exiting = true;
        path = seeker.StartPath(transform.position, exit.transform.position, OnPathComplete);
        yield return StartCoroutine(path.WaitForPath());
    }

    IEnumerator standStill()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(pathToExit());
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
        }
    }

    void DestroyShidder()
    {
        Destroy(exit);
        Destroy(gameObject);
    }

    void dropShid()
    {       
        Instantiate(shid, transform.position, Quaternion.identity);

        spriteRenderer.sprite = relaxedSprite;
    }
}
