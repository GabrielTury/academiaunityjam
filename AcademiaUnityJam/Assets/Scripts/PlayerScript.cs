using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerScript : MonoBehaviour
{
    public PlayerManager playerManager;
    public DialogueManager dialogueManager;
    private Animator anima;
    public AudioSource slash1;
    public AudioSource slash2;
    public AudioSource slash3;
    public AudioSource slashLobo;
    public AudioSource walking;
    bool maxJump;

    float playerDirection;
    Vector2 scale;
    bool human = true;

    #region Run Variables
    [Header ("Run Stats")]
    public float acceleration;
    private float initialAcceleration;

    public float GetinitialAcceleration
    {
        get { return initialAcceleration; }
        set { initialAcceleration = value; }
    }

    public float maxSpeed;
    private float maxSpeed0;

    public float GetMaxSpeed0
    {
        get { return maxSpeed0; }
    }

    #endregion

    #region Attack Variables
    [Header ("Attack Stats")]
    
    public float attackRange;

    [SerializeField]
    private Transform attackPoint1, attackPoint2, attackPoint3;

    //[SerializeField]
    private int damageColor1 = 0, damageColor2 = 1, damageColor3 = 2;

    private bool canAttack1 = true, canAttack2 = true, canAttack3 = true, canAttackWolf1 = true, canAttackWolf2 = true, isAttacking;
/*    private float attack1Cooldown, attack2Cooldown, attack3Cooldown, attackWolfCooldown, attackWolf2Cooldown;

    private float lastAttack1 = 100, lastAttack2 = 100, lastAttack3 = 100, lastAttackWolf = 10, lastAttackWolf2 = 10;*/

    [SerializeField]
    private LayerMask enemyLayer;
    #endregion

    #region Player Health
    [SerializeField]
    private int maxHealth;

    private float currentHealth;
    #endregion

    #region Jump Variables
    [Header("Jump Stats")]
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask groundLayer;

    private float coyoteTime = 0.3f;
    private float lastOnGroundTime;
    private bool isJumping;
    public float jumpForce;
    #endregion

    #region Components
    private Rigidbody2D playerRbd;
    internal Controls playerInputs;
    #endregion


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerManager.healthFill.fillAmount = currentHealth / 100;

        if (currentHealth < 0)
        {
            //Game Over
            playerManager.GameOver();
        }
    }

    private void Awake()
    {
        playerInputs = new Controls();
        playerInputs.Player.Enable();
        playerInputs.Player.Jump.performed += Jump;
        playerInputs.Player.Morph.started += Morph;        
        playerInputs.Player.Attack1.started += Attack1;
        playerInputs.Player.Attack2.started += Attack2;
        playerInputs.Player.Attack3.started += Attack3;
        playerInputs.Player.NextDialogue.started += NextDialogue_started;
        playerInputs.Player.Dodge.started += Dodge;



    }

    #region Dodge
    private void Dodge(InputAction.CallbackContext obj)
    {
        //Dash pra frente que torna o char invulneravel e atravessa inimigos
    }
    #endregion
    private void NextDialogue_started(InputAction.CallbackContext obj)
    {
        dialogueManager.DisplayNextSentence();
    }

    void Start()
    {
        initialAcceleration = acceleration;
        maxSpeed0 = maxSpeed;
        currentHealth = maxHealth;
        playerRbd = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    #region Updates
    private void FixedUpdate()
    {
       // print(playerRbd.velocity.y);
        playerDirection = playerInputs.Player.Movement.ReadValue<float>();

        if(playerDirection!=0)
            Run();
        else
            Break();

        if (playerRbd.velocity.y <= 3 && !IsGrounded() && !maxJump)
        {
            maxJump = true;
            playerRbd.gravityScale = 5f;
            playerRbd.velocity = new Vector2(playerRbd.velocity.x, 0);
        }
        else if (IsGrounded())
        {
            playerRbd.gravityScale = 1f;
            maxJump = false;
        }

    }
    void Update()
    {

        anima.SetBool("Human", human);

        anima.SetFloat("Velocity", Mathf.Abs(playerRbd.velocity.x));
        anima.SetFloat("VelocityY",Mathf.Abs(playerRbd.velocity.y));
        anima.SetBool("IsGrounded", IsGrounded());
        //Coyote Time 
        if (IsGrounded())
        {
            lastOnGroundTime = coyoteTime;
        }
        else
        {
            lastOnGroundTime -= Time.deltaTime;
        }
    }
    #endregion

    #region Attacks    
    private void Attack3(InputAction.CallbackContext obj)
    {
        if (human && canAttack3 && !isAttacking)
        {
            DoDamage(attackPoint3, attackRange, damageColor3);
            canAttack3= false;
            isAttacking = true;
            anima.SetTrigger("Attack3");
            slash1.Play();

        }
    }
    private void Attack2(InputAction.CallbackContext obj)
    {
        if (human && canAttack2 && !isAttacking)
        {
            DoDamage(attackPoint2, attackRange, damageColor2);
            canAttack2= false;
            isAttacking = true;
            anima.SetTrigger("Attack2");
            slash2.Play();
        }
        /*else if (!human && canAttackWolf2 && !isAttacking)
        {

            DoDamage(attackPoint2, attackRange, 4);
            canAttackWolf2= false;
            isAttacking = true;
            slashLobo.Play();
        }*/

    }
    
    private void Attack1(InputAction.CallbackContext obj)
    {
        if (human && canAttack1 && !isAttacking)
        {

            DoDamage(attackPoint1, attackRange, damageColor1);
            canAttack1 = false;
            isAttacking = true;
            anima.SetTrigger("Attack1");
            slash3.Play();
        }
        else if(!human && canAttackWolf1 && !isAttacking)
        {

            DoDamage(attackPoint1, attackRange, 4);
            canAttackWolf1= false;
            isAttacking = true;
            anima.SetTrigger("AttackWolf1");
            
        }
    }

    public void ResetAttack(string whichAttack)
    {
        isAttacking = false;
        switch(whichAttack)
        {
            case "Attack1":
                canAttack1 = true;
                break;
            case "Attack2":
                canAttack2 = true;
                break;
            case "Attack3":
                canAttack3 = true;
                break;
            case "WolfAttack1":
                canAttackWolf1= true;
                break;
/*            case "WolfAttack2":
                canAttackWolf2= true;
                break;*/

        }
    }


    private void DoDamage(Transform attackPoint,float attackRange, int damageColor)
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.CompareTag("Melee"))
                enemy.GetComponent<BasicEnemy>().TakeDamageShield(damageColor);
            else if (enemy.CompareTag("Ranged"))
                enemy.GetComponent<RangedEnemy>().TakeDamageShield(damageColor);
            else if (enemy.CompareTag("Boss"))
                enemy.GetComponent<Boss_Script>().TakeDamageShield(damageColor);
        }
    }

    #endregion

    #region Movement
    #region Jump
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (lastOnGroundTime > 0f && !isJumping)
            {
                playerRbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
               
                lastOnGroundTime = 0f;
                StartCoroutine(JumpCooldown());
            }
        }

        IEnumerator JumpCooldown()
        {
            isJumping = true;
            yield return new WaitForSeconds(0.35f);
            isJumping = false;

        }
        
        
    }

    //Checa se est? encostando no ch?o
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundLayer);
    }
    #endregion

    #region Run
    /// <summary>
    /// Movimenta o personagem para os lados
    /// </summary>
    private void Run()
    {
        playerRbd.AddForce(new Vector2 (playerDirection, 0f) * acceleration, ForceMode2D.Force);

        //Checa se o input est? na mesma dire??o do personagem
        if (Mathf.Sign(playerDirection) != Mathf.Sign(scale.x) && playerDirection != 0f)
        {
            ChangeDirection();
            walking.Play();
        }
        else
        {
            walking.Stop();
        }

        //Limita a velocidade do personagem
        if (Mathf.Abs(playerRbd.velocity.x) > maxSpeed)
        {
            //print(maxSpeed);
            acceleration = 0f;
        }
        else
        {
            acceleration = initialAcceleration;
        }
    }

    private void Break()
    {
        if (IsGrounded() && playerDirection == 0)
        {
            playerRbd.velocity = new Vector2(0,playerRbd.velocity.y);
        }
    }

    //Troca direcao do personagem conservando parte da sua velocidade
    void ChangeDirection()
    {
        scale = transform.localScale;
        scale.x = 1f * Mathf.Sign(playerDirection);
        transform.localScale = scale;
        float actualVelocity;
        actualVelocity = playerRbd.velocity.x;
        actualVelocity *= -0.9f;
        playerRbd.velocity = new Vector2(actualVelocity, playerRbd.velocity.y);
    }
    #endregion

    #endregion

    #region Trocas
    private void Morph(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Troca de humano para lobo
            if (human && playerManager.wolfFill.fillAmount == 1f)
            {
                //playerInputs.Player.Disable();
                //playerInputs.Lobo.Enable();
                human= false;
                isAttacking = false;

                playerManager.ResetWolfBar(10);
                playerManager.FillHealthBar();
                currentHealth = maxHealth;
                attackRange = 4f;


            }                 
            
        }
    }

    public void UnMorph()
    {
        human = true;
        isAttacking = false;
        attackRange = 1.6f;
    }

    #endregion

    public void OnDisable()
    {
        playerInputs.Player.Jump.performed -= Jump;
        playerInputs.Player.Morph.started -= Morph;
        playerInputs.Player.Attack1.started -= Attack1;
        playerInputs.Player.Attack2.started -= Attack2;
        playerInputs.Player.Attack3.started -= Attack3;
        playerInputs.Player.NextDialogue.started -= NextDialogue_started;
        playerInputs.Player.Dodge.started -= Dodge;
        playerInputs.Player.Disable();
    }


    #region Gizmos
    //Desenha a esfera no pe do personagem para visualizacao
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckPoint.position, 0.2f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange);
    }
    #endregion
}
