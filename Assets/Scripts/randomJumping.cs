using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomJumping : MonoBehaviour
{
    //private Rigidbody2D rb2d;
    private float randomWaitingTime;
    private float objWidth;
    private float objheight;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        randomWaitingTime = Random.Range(1, 10);
        objWidth = getObjWidth();
        objheight = getObjHeight();
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (randomWaitingTime > 0)
        {
            randomWaitingTime-= Time.deltaTime;
        }
        else
        {
            float nextX = Random.Range(-12.5f + objWidth/2, 12.5f - objWidth/2);
            float nextY = Random.Range(-12.5f + objheight/2, 12.5f - objheight/2);
            Vector3 nextPos = new Vector3(nextX, nextY, 0);

            gameObject.transform.position = nextPos;
            randomWaitingTime = Random.Range(1, 10);
        }
        

        
    }

    private float getObjHeight()
    {
        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        return (p2.x - p1.x);
        
    }

    private float getObjWidth()
    {
        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        return (p2.y - p1.y);
    }

}
