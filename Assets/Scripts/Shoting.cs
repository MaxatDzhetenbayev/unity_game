using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public GameObject bullet;
    public Transform shoot;
    public float timeShoot = 3;



    // Start is called before the first frame update
    void Start()
    {
        shoot.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        StartCoroutine(shooting());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        Instantiate(bullet, shoot.transform.position, transform.rotation);
        StartCoroutine(shooting());
    }

}
