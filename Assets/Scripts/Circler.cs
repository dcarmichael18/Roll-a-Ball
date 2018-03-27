using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circler : MonoBehaviour
{

    public float speed =        3.0f;
    private float yMax =        9.5f;
    private float yMin =        3.5f;   // starting position
    public int direction =      1;      // up to start
    private float rotation =    0f;
    public float position =     1f;     // where in the circle it starts

    private void Start()
    {
        rotation = position * ((Mathf.PI * 2) / 12);
    }

    // Update is called once per frame
    void Update()
    {
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

        rotation += .01f;

        float xNew = 6 * Mathf.Sin(rotation);
        float zNew = 6 * Mathf.Cos(rotation);

        transform.position = new Vector3(xNew, yNew, zNew);
    }
}
