using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedecineChest : MonoBehaviour
{
    private int bonusHealth = 25;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (collision.gameObject.CompareTag("Player"))
        {
            health.setHealth(bonusHealth);
            Destroy(gameObject);
        }
    }
}
