using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject button;

    private void Start()
    {
        
    }
    void Update()
    {

        if (button.activeSelf == true)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }


   
}
