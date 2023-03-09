using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public void CreateAura(int auraColor, int manyAuras, BasicEnemy enemy)

    {
        enemy.auraShield1 = auraColor;

        if (manyAuras >= 1)
        {
            do
            {

                enemy.auraShield2 = Random.Range(0, 3);

            }
            while (enemy.auraShield2 == enemy.auraShield1);

            enemy.auraShield3 = -1;

        }

        if (manyAuras == 2)
        {
            do
            {
                enemy.auraShield3 = Random.Range(0, 3);

            }
            while (enemy.auraShield3 == enemy.auraShield1 || enemy.auraShield3 == enemy.auraShield1);
        }
        else if (manyAuras == 0)
        {

            enemy.auraShield2 = -1;
            enemy.auraShield3 = -1;

        }



        //print(auraShield1 + auraShield2 + auraShield3); 
    }



}
