using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{

    public Transform point1;
    public Transform point2;
    public float speed = 3f;
    bool canGo = true;

    private float rotationSpeed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0 , rotationSpeed + Time.deltaTime);

        if (canGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        }

        if (transform.position == point1.position)
        {
            Transform d = point1;
            point1 = point2;
            point2 = d;
            canGo = false;
            
            if (transform.rotation.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            canGo = true;
        }
        
    }


}

