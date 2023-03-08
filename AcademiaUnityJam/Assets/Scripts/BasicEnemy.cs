using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField, HideInInspector] private LayerMask playerLayer;

    private PlayerScript playerScript;
    private PlayerManager playerManager;
    public int maxHealth;
    private int currentHealth;

    private int auraShield1, auraShield2, auraShield3;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerScript = FindObjectOfType<PlayerScript>();

        currentHealth = maxHealth;

        CreateAura(Random.Range(0, 4),Random.Range(0,3));
    }

    #region Doing Damage
    private void Attack()
    {
        
    Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        if(playerHit != null)
        {
            playerScript.TakeDamage(10);
        }
        
    }

#endregion

#region Aura Creation
public void CreateAura(int auraColor,int manyAuras)
    
    {
        switch(auraColor)
        {
            case 0:
                //falta colocar o visual da Aura (fazer na função aura color)

                auraShield1 = 0;
                break;
            case 1:
                //falta colocar o visual da Aura
                auraShield1 = 1;
                break;
            case 2:
                //falta colocar o visual da Aura
                auraShield1 = 2;
                break;
            case 3:
                //falta colocar o visual da Aura
                auraShield1 = 3;
                break;
        }

        if(manyAuras >= 1)
        {
            do 
            { 

                auraShield2 = Random.Range(0, 4);

            }
            while(auraShield2 == auraShield1);

            auraShield3 = -1;
            
        }
        
        if(manyAuras == 2)
        {
            do
            {
                auraShield3 = Random.Range(0, 4);

            }
            while (auraShield3 == auraShield1 || auraShield3 == auraShield1);
        }else if(manyAuras == 0)      
        {

            auraShield2 = -1;
            auraShield3 = -1;

        }



        //print(auraShield1 + auraShield2 + auraShield3); 
    }

    private void AuraVisual(int auraColor)
    {

    }
    #endregion

    #region Taking Damage
    public void TakeDamageShield(int damageColor)
    {
        //Animação de tomar dano

        //toma dano
        if (auraShield1 == -1 && auraShield2 == -1 && auraShield3 == -1)
        {
            TakeDamageHealth(40);
        }


        if (auraShield1 == damageColor) 
        {

            //Destrói a aura


            //Toma o dano
            auraShield1 = -1;

        }
        else if(auraShield2 == damageColor)
        {

            auraShield2 = -1;

        }
        else if(auraShield3 == damageColor)
        {

            auraShield3 = -1;

        }else if (damageColor == 4)
        {
            TakeDamageHealth(40);
        }

        

    }

    private void TakeDamageHealth(int damage)
    {

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //animação de morrer


        //recarrega a barra de Lobo
        playerManager.FillWolfBar();

        //Trocar destroy por pull
        Destroy(gameObject);
    }
    #endregion
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
