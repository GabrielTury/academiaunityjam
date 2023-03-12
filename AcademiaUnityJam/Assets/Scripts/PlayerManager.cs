using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    bool start = false;

    public Image wolfFill;
    public Image healthFill;
    public GameObject wolfReady, wolfAttack1, wolfAttack2, attackGreen;
    public GameObject gameOver;

    public PlayerScript playerScript;

    private float wolfTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FillHealthBar()
    {
        healthFill.fillAmount = 1;
    }

    public void FillWolfBar()
    {
        wolfFill.fillAmount += 0.2f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }



    public void ResetWolfBar(float wolfTime)
    {
        wolfTimer = wolfTime;
        start= true;
        wolfReady.SetActive(true);
        wolfAttack1.SetActive(true);
        wolfAttack2.SetActive(true);
        attackGreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            wolfTimer -= Time.deltaTime;
            wolfFill.fillAmount = wolfTimer/10;
        }


        if (wolfTimer <= 0 && start)
        {
            playerScript.UnMorph();
            wolfFill.fillAmount = 0;
            start = false;
            wolfReady.SetActive(false);
            wolfAttack1.SetActive(false);
            wolfAttack2.SetActive(false);
            attackGreen.SetActive(true);
        }
    }
}
