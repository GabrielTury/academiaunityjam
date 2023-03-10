using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyManager
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;



    private bool isAttacking = false;

    

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerScript = FindObjectOfType<PlayerScript>();
        anima = GetComponent<Animator>();

        currentHealth = maxHealth;

        CreateAura(Random.Range(0, 3),Random.Range(0,3));
    }

    private void Update()
    {

        if(!isAttacking)
        {
            Collider2D playerHit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);


            if (playerHit != null)
            {
                print("Acertou");
                anima.SetTrigger("Attack");
                //StartCoroutine(Attack(playerHit));
                isAttacking = true;
            }
        }
    }

    #region Doing Damage
    public void Attack()
    {
        playerScript.TakeDamage(10);

        //yield return new WaitForSeconds(3);

        anima.ResetTrigger("Attack");
        isAttacking= false;

    }

    #endregion

    #region Aura Creation


    private void AuraVisual(int auraColor)
    {

    }
    #endregion

    #region Taking Damage
    public void TakeDamageShield(int damageColor)
    {
        //Anima��o de tomar dano

        //toma dano
        if (auraShield1 == -1 && auraShield2 == -1 && auraShield3 == -1)
        {
            TakeDamageHealth(40);
        }


        if (auraShield1 == damageColor) 
        {

            //Destr�i a aura


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
        //anima��o de morrer


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
