using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public float timeToDisable = 6f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisable());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(timeToDisable);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisable());
        Destroy(gameObject);
    }

}
