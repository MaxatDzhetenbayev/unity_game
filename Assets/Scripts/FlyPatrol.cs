using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPatrol : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 1.8f;
    bool canGo = true;
    public float turnTIme; 




    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
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
            StartCoroutine(waitFly());
        }


        IEnumerator waitFly()
        {
            yield return new WaitForSeconds(turnTIme);
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
