using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public float Speed;
    private float currentSpeed;
    public float JumpForce;
    private Rigidbody2D rb;
    private float dirX = 0f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    [Header ("Jump")]
    private float jumpDuration = 0.5f;
    public bool isJumping = false;  // Ban đầu, đặt isJumping là false

    [Header("Knock")] 
    public float KbForce;
    public float KbCounter;
    public float KbTotalTime;

    public bool KnockFromRight;
    private float knockbackRecoveryTime = 1.0f; // Thời gian để khôi phục Speed sau Knockback
    private float knockbackRecoveryTimer = 0.0f;
    private bool isKnockedBack = false;

    [Header("CheckPoint")]
     private Vector3 respawnPoint;

    [Header("Music")]
    [SerializeField] private AudioSource ded;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource checkPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 3;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    } 

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
     
        if (isKnockedBack)
        {
            knockbackRecoveryTimer += Time.deltaTime;

            if (knockbackRecoveryTimer >= knockbackRecoveryTime)
            {
            // Khôi phục Speed sau thời gian đã đủ
                Speed = currentSpeed;
                isKnockedBack = false;
            }
        }

        
    }

    private void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (!isKnockedBack)
        {
            rb.velocity = new Vector2(dirX * Speed, rb.velocity.y);
        }
    
    
        anim.SetBool("IsWalking", !isKnockedBack && dirX != 0);

        if (Input.GetButtonDown("Jump") && !isKnockedBack)
        {
            StartCoroutine(JumpAndResetIsJumping());
        }
    
   
        if (player.transform.position.y <= -12)
        {
            Die();
        }
    }

    private IEnumerator JumpAndResetIsJumping()
    {
        isJumping = true;
        Jump();  // Gọi hàm nhảy
        yield return new WaitForSeconds(jumpDuration);
        isJumping = false;  // Sau 0.5 giây, đặt isJumping là false
        
    }



    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce); 
            jump.Play();
        }
    }

    private void Rotate()
    {
        if (dirX > 0f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if (dirX < 0f)
        {
           transform.localScale = new Vector3(-1f,1f,1f);
        } 
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,  jumpableGround);
    }

    public void HandleKnockback()
    {
        isKnockedBack = true;
        knockbackRecoveryTimer = 0.0f;

        if (KnockFromRight)
        {
            rb.velocity = new Vector2(-KbForce, KbForce);
        }
        else
        {
            rb.velocity = new Vector2(KbForce, KbForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if(other.gameObject.CompareTag("CheckPoint"))
        {
            checkPoint.Play();
            Invoke(nameof(NextLevel), 0.5f);
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ded.Play();
        anim.SetTrigger("Ded");
        Invoke(nameof(Spawn), 1f);
    }

    private void Spawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }      

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  
}
