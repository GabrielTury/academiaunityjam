using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Script : EnemyManager
{
    #region Variables
    [Header ("Range Stats")]
    [SerializeField] private float meleeAttackRange;
    [SerializeField] Transform rangedAttackRange, attackPointRanged, attackPointMelee,patrolPoint1,patrolPoint2;
    Rigidbody2D rdbd;
    bool isAttacking;
    public LayerMask playerLayer;

    float timer;
    
    public AudioSource mosketeerTiro;

    [SerializeField] private GameObject bullet;

    #endregion





    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerScript = FindObjectOfType<PlayerScript>();
        rdbd= GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

        currentHealth = maxHealth;
        currentWaypoint = patrolPoint2.position;

        CreateAura(Random.Range(0, 3), Random.Range(0, 3));
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
            rdbd.velocity = new Vector2(speed, rdbd.velocity.y);
    }
    void Update()
    {

        anima.SetFloat("Velocity", rdbd.velocity.x);

        if (!isAttacking && currentHealth > 150)
        {
            Patrol(patrolPoint1, patrolPoint2);
            Collider2D playerHit = Physics2D.OverlapArea(transform.position, rangedAttackRange.position, playerLayer);


            if (playerHit != null)
            {
                anima.SetTrigger("AttackRanged");
                mosketeerTiro.Play();
                isAttacking = true;
                playerHit = null;
            }
        }
        else if(currentHealth <= 150 && !isAttacking)
        {
            Collider2D playerHit = Physics2D.OverlapCircle(attackPointMelee.position, meleeAttackRange, playerLayer);
            Patrol(patrolPoint1, patrolPoint2);

            if (playerHit != null)
            {

                rdbd.velocity = Vector2.zero;
                print(playerHit.name);
                anima.SetTrigger("AttackMelee");
                //StartCoroutine(Attack(playerHit));
                isAttacking = true;
                playerHit = null;
            }
            
        }
        else if (currentHealth<= 100)  
        {
            isAttacking = false;
        }

    }



    #region Take Damage
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
        else if (auraShield2 == damageColor)
        {
            AuraDestroy(auraShield2);
            auraShield2 = -1;

        }
        else if (auraShield3 == damageColor)
        {
            AuraDestroy(auraShield3);
            auraShield3 = -1;

        }
        else if (damageColor == 4)
        {
            TakeDamageHealth(40);
        }



    }

    private void TakeDamageHealth(int damage)
    {

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {


        //Tocar os créditos
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Trocar destroy por pull
        Destroy(gameObject);
    }
    #endregion


    #region Attacks




    public void Attack()
    {
        Instantiate(bullet, attackPointRanged.position, attackPointRanged.rotation);
        isAttacking = false;
    }

    public void AttackMelee()
    {
        playerScript.TakeDamage(10);
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, rangedAttackRange.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(currentWaypoint, patrolPointRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPointMelee.position, meleeAttackRange);
    }




}

