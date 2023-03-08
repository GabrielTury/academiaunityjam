using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerScript : MonoBehaviour
{
    public PlayerManager playerManager;

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

    #endregion

    #region Attack Variables
    [Header ("Attack Stats")]
    
    public float attackRange;

    [SerializeField]
    private Transform attackPoint1, attackPoint2, attackPoint3, attackPoint4;

    //[SerializeField]
    private int damageColor1 = 0, damageColor2 = 1, damageColor3 = 2, damageColor4 = 3;

    [SerializeField]
    private float attack1Cooldown, attack2Cooldown, attack3Cooldown, attack4Cooldown;

    private float lastAttack1 = 100, lastAttack2 = 100, lastAttack3 = 100, lastAttack4 = 100, lastAttackWolf = 10;

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
    private Controls playerInputs;
    #endregion


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            //Game Over
            print("dead");
        }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        playerInputs = new Controls();
        playerInputs.Player.Enable();
        playerInputs.Player.Jump.performed += Jump;
        playerInputs.Player.Morph.started += Morph;        
        playerInputs.Player.Attack1.started += Attack1;
        playerInputs.Player.Attack2.started += Attack2;
        playerInputs.Player.Attack3.started += Attack3;
        playerInputs.Player.Attack4.started += Attack4;
        playerRbd = GetComponent<Rigidbody2D>();


    }



    void Start()
    {
        initialAcceleration = acceleration;
    }

    #region Updates
    private void FixedUpdate()
    {

        playerDirection = playerInputs.Player.Movement.ReadValue<float>();

        /*if (human)
        {
            playerDirection = playerInputs.Player.Movement.ReadValue<float>();        
        }
        else
        {
            playerDirection = playerInputs.Lobo.Movement.ReadValue<float>();          
        }*/

        Run();
        
    }
    void Update()
    {
        //Coyote Time 
        if (IsGrounded())
        {
            lastOnGroundTime = coyoteTime;
        }
        else
        {
            lastOnGroundTime -= Time.deltaTime;
        }

        lastAttack1 += Time.deltaTime;
        lastAttack2 += Time.deltaTime;
        lastAttack3 += Time.deltaTime;
        lastAttack4 += Time.deltaTime;
        lastAttackWolf += Time.deltaTime;
    }
    #endregion

    #region Attacks    
    private void Attack4(InputAction.CallbackContext obj)
    {
        if (human && lastAttack4 > attack4Cooldown)
        {
            DoDamage(attackPoint4, attackRange, damageColor4);

            lastAttack4 = 0f;

            print("ataque 4");
        }
    }

    private void Attack3(InputAction.CallbackContext obj)
    {
        if (human && lastAttack3 > attack3Cooldown)
        {
            DoDamage(attackPoint3, attackRange, damageColor3);

            lastAttack3 = 0f;

            print("ataque 3");
        }
    }
    private void Attack2(InputAction.CallbackContext obj)
    {
        if (human && lastAttack2 > attack2Cooldown)
        {
            DoDamage(attackPoint2, attackRange, damageColor2);

            lastAttack2 = 0f;

            print("ataque 2 humano");
        }
    }
    
    private void Attack1(InputAction.CallbackContext obj)
    {
        print(lastAttack1);
        if (human && lastAttack1 > attack1Cooldown)
        {

            DoDamage(attackPoint1, attackRange, damageColor1);

            lastAttack1 = 0f;

            print("ataque 1 humano");
        }
        else if(!human/*colocar cooldown do lobo aqui*/)
        {

            DoDamage(attackPoint1, attackRange, 4);

            lastAttackWolf = 0f;

            print("ataque 1 lobo");
        }
    }


    private void DoDamage(Transform attackPoint,float attackRange, int damageColor)
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<BasicEnemy>().TakeDamageShield(damageColor);
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

    //Checa se está encostando no chão
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

        //Checa se o input está na mesma direção do personagem
        if (Mathf.Sign(playerDirection) != Mathf.Sign(scale.x) && playerDirection != 0f)
        {
            ChangeDirection();
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

    //Troca direcao do personagem conservando parte da sua velocidade
    void ChangeDirection()
    {
        scale = transform.localScale;
        scale.x = 1f * Mathf.Sign(playerDirection);
        transform.localScale = scale;
        float actualVelocity;
        actualVelocity = playerRbd.velocity.x;
        actualVelocity *= -0.3f;
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
            if (human && playerManager.slider.value == 1f)
            {
                //playerInputs.Player.Disable();
                //playerInputs.Lobo.Enable();
                human= false;
                maxSpeed += 3f;
                jumpForce -= 3f;

                playerManager.ResetWolfBar(10);

                print("Virou lobo");
            }
            //troca de lobo para humano
            //else
            //{
            //    //playerInputs.Player.Enable();
            //    //playerInputs.Lobo.Disable();
            //    human= true;
            //    maxSpeed -= 3f;
            //    jumpForce += 3f;
            //    print("Virou Humano");
            //}                   
            
        }
    }

    public void UnMorph()
    {
        human = true;
        maxSpeed -= 3f;
        jumpForce += 3f;
        print("Virou Humano");
    }

    #endregion
    


    #region Gizmos
    //Desenha a esfera no pe do personagem para visualizacao
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckPoint.position, 0.2f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
    }
    #endregion
}
