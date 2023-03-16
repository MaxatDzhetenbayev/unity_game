using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform point1, point2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;

    private void Start()
    {
        nextPos = startPos.position;
    }
    void Update()
    {
        if(transform.position == point1.position)
        {
            nextPos = point2.position;
        }
        else if(transform.position == point2.position)
        {
            nextPos = point1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
