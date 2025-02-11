using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public Transform platform;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < 0.05f)
        {
            currentPoint++;
        }

        if (currentPoint >= points.Length)
        {
            currentPoint = 0;
        }
    }
}
