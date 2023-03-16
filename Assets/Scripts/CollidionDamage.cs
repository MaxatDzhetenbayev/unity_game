using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidionDamage : MonoBehaviour
{

    public int damage;
    public string objectTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectTag))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.takeHit(damage);

        }
    }
}
