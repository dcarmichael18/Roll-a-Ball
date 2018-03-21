using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour {

    public  float   speed =     5.0f;
    private float   yMax =      3.0f;
    private float   yMin =      0.5f;    //starting position
    private int     direction = 1;      //up to start
    private float   xSet;
    private float   zSet;

    private void Start()
    {
        xSet = transform.position.x;
        zSet = transform.position.z;
    }

    // Update is called once per frame
    void Update () {
        float yNew = transform.position.y + direction * speed * Time.deltaTime;
        

        if (yNew >= yMax)
        {
            yNew = yMax;
            direction *= -1;
        }
        else if (yNew <= yMin)
        {
            yNew = yMin;
            direction *= -1;
        }

        transform.position = new Vector3(xSet, yNew, zSet);
	}
}
