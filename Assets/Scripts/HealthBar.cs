using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider Bar;
    public Health playerHealth;
    public float smoothing = 4f;

    void Start()
    {
        SetMaxHealth(playerHealth.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(playerHealth.health);
    }

    public void SetMaxHealth(int health)
    {
        Bar.maxValue = health;
        Bar.value = health;
    }

    public void SetHealth(int health)
    {

        Bar.value = Mathf.Lerp(Bar.value, playerHealth.health, smoothing * Time.deltaTime ) ;
    }


}
