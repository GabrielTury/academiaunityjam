using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    

    protected Animator anima;
    protected PlayerScript playerScript;
    protected PlayerManager playerManager;
    public int maxHealth;
    protected int currentHealth;
    [SerializeField] protected float speed;
    [SerializeField] protected float patrolPointRange;
    protected Vector3 currentWaypoint;

    protected int auraShield1, auraShield2, auraShield3;


    #region Aura
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
    #endregion

    #region Patrol

    protected void Patrol(Transform patrolPoint1, Transform patrolPoint2)
    {

        //print(Vector2.Distance(currentWaypoint, transform.position) + "dist trans para patrol 2" + Vector2.Distance(transform.position, patrolPoint2.position));
        
        //enemyRdbd.velocity = Vector3.zero;
        

        if(Vector2.Distance(transform.position,currentWaypoint) < patrolPointRange && patrolPoint2.position == currentWaypoint)
        {
            //print("a");
            transform.Rotate(0f, 180f, 0f);

            speed *= -1f;

            currentWaypoint = patrolPoint1.position;

        }
        else if (Vector2.Distance(transform.position, currentWaypoint) < patrolPointRange && patrolPoint1.position == currentWaypoint)
        {
            //print("b");
            currentWaypoint = patrolPoint2.position;

            transform.Rotate(0f, 180f, 0f);

            speed *= -1f;
        }
        else if (currentWaypoint == Vector3.zero)
        {
            currentWaypoint = patrolPoint1.position;
        }
    }

    #endregion

}
