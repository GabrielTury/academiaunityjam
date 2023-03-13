using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyManager
{
    [SerializeField] private Transform patrolPoint1, patrolPoint2;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;

    private Rigidbody2D rdbd;

    public AudioSource whip;

    private bool isAttacking = false;

    

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerScript = FindObjectOfType<PlayerScript>();
        anima = GetComponent<Animator>();
        rdbd = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        CreateAura(Random.Range(0, 3),Random.Range(0,3));

        currentWaypoint = patrolPoint2.position;
       
    }

    private void FixedUpdate()
    {
        if(!isAttacking)
        rdbd.velocity = new Vector2(speed, rdbd.velocity.y);
    }

    private void Update()
    {

       

        
        
            
            

        

        if(!isAttacking)
        {
            Patrol(patrolPoint1, patrolPoint2);

            Collider2D playerHit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);


            if (playerHit != null)
            {

                rdbd.velocity = Vector2.zero;
                print(playerHit.name);
                anima.SetTrigger("Attack");
                whip.Play();
                //StartCoroutine(Attack(playerHit));
                isAttacking = true;
                playerHit = null;
            }
        }
    }

    #region Doing Damage
    public void Attack()
    {
        playerScript.TakeDamage(10);

    }
    private void CheckAttack()
    {
        Collider2D playerHit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);


        if (playerHit != null)
        {
            anima.SetTrigger("Attack");
            playerHit = null;
        }
        else
        {
            ResumePatrol();
        }
    }

    private void ResumePatrol()
    {
        isAttacking = false;
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

            AuraDestroy(auraShield1);
            //Toma o dano
            auraShield1 = -1;

        }
        else if(auraShield2 == damageColor)
        {
            AuraDestroy(auraShield2);
            auraShield2 = -1;

        }
        else if(auraShield3 == damageColor)
        {
            AuraDestroy(auraShield3);
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(currentWaypoint, patrolPointRange);
    }

}
