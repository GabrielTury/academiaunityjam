using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    protected Animator anima;
    protected PlayerScript playerScript;
    protected PlayerManager playerManager;
    public int maxHealth;
    protected int currentHealth;

    protected int auraShield1, auraShield2, auraShield3;


    public void CreateAura(int auraColor, int manyAuras)

    {
        auraShield1 = auraColor;

        if (manyAuras >= 1)
        {
            do
            {

                auraShield2 = Random.Range(0, 3);

            }
            while (auraShield2 == auraShield1);

            auraShield3 = -1;

        }

        if (manyAuras == 2)
        {
            do
            {
                auraShield3 = Random.Range(0, 3);

            }
            while (auraShield3 == auraShield1 || auraShield3 == auraShield1);
        }
        else if (manyAuras == 0)
        {

            auraShield2 = -1;
            auraShield3 = -1;

        }



        //print(auraShield1 + auraShield2 + auraShield3); 
    }


}
