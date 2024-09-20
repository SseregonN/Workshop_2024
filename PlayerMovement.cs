using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 // Les variables :
  
    // Des déplacements
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    private float horizontalMovement;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    //Du saut
    public bool isGrounded;
    public bool isJumping;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    void Update()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //


        if (Input.GetButtonDown("Jump") && isGrounded) // condition pour savoir si le joueur peut sauter : il faut appuyer sur la barre d'espace + le joueur est au sol (on le sait grace a un point "groundCheck")
        {
            isJumping = true;
        }
        

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x); // Pour rester en positif dans les deplacements
        animator.SetFloat("Speed", characterVelocity);


    }
    //Fonction dans laquelle on regarde si il a un bloc a ses pied grace a un point situé sous ses pieds. 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement);

        
    }
    //Déplacements du joueur, on reste sur des mouvements de gauche à droite
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        // Le joueur saute-il ?
        if (isJumping == true) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;

        }
    }
        //Animation pour que le personnage se retourne
        void Flip(float _velocity)
        { // pour retourner le personnage sur le spriteRenderer donc on change le x avant le changement
            if (_velocity > 0.1f)
            {
                spriteRenderer.flipX = false;
            }
            else if (_velocity < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
