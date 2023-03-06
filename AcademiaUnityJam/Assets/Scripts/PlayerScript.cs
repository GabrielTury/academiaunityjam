using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerScript : MonoBehaviour
{

    float playerDirection;
    Vector2 scale;

    #region Run Variables
    [Header ("Run Stats")]
    public float acceleration;
    private float initialAcceleration;
    public float maxSpeed;

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



    // Start is called before the first frame update

    private void Awake()
    {
        playerInputs = new Controls();
        playerInputs.Player.Enable();
        playerInputs.Player.Jump.performed += Jump;
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
        if (Mathf.Sign(playerDirection) != Mathf.Sign(scale.x))
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

    // Update is called once per frame
    


    #region Gizmos
    //Desenha a esfera no pe do personagem para visualizacao
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckPoint.position, 0.2f);
    }
    #endregion
}
