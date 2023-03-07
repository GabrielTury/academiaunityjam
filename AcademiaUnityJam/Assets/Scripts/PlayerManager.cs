using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    bool start = false;

    public Slider slider;

    public PlayerScript playerScript;

    private float wolfTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void FillWolfBar()
    {
        slider.value += 0.1f;
    }

    public void ResetWolfBar(float wolfTime)
    {
        wolfTimer = wolfTime;
        start= true;
    }
    // Update is called once per frame
    void Update()
    {
        if (start)
        wolfTimer -= Time.deltaTime;


        if (wolfTimer <= 0 && start)
        {
            playerScript.UnMorph();
            slider.value = 0;
            start = false;
        }
    }
}
