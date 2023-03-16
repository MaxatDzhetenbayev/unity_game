using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public  int health;
    public int maxHealth;
    public Health playerHealth;

    public void takeHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);

        }

        if (playerHealth.health <= 0)
        {
            Restarting();

        }

    }

    void Restarting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void setHealth(int bonushealth)
    {
        health += bonushealth;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

}
