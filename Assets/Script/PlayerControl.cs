using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager GameManager;
    public float speed = 5f;
    public float jumpForce = 7f;
    public bool facingRight = true;
    public int hp = 5;

    public Animator animator;
    public Rigidbody2D rb;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    //public GameObject BulletPrefab;
    public Transform FirePoint;
    public float FireRate = 10f;
    public State currentState;

   [ Header("Double Jump")]
    [HideInInspector] public bool canDoubleJump = false;
    [HideInInspector] public bool hasDoubleJumped = false;

    [Header("Blink")]
    private SpriteRenderer spriteRenderer;
    private bool isBlinking = false;
    public float blinkDuration = 0.2f; // Thời gian mỗi lần nhấp nháy
    // Input flags
    public float InputMove { get; private set; }
    public bool IsJumpPress { get; private set; }
    public bool IsAttackPress { get; set; }
    public bool IsGrounded { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = new IdleState(this); // Bắt đầu bằng Run
        currentState.Enter();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        InputMove = Input.GetAxisRaw("Horizontal");
       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsJumpPress = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            IsAttackPress = true;
        }

        // --- Flip nhân vật ---
        if (InputMove > 0 && !facingRight)
            Flip();
        else if (InputMove < 0 && facingRight)
            Flip();

        // --- Kiểm tra grounded ---
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (IsGrounded)
        {
            canDoubleJump = true;
            hasDoubleJumped = false;
        }

        // --- Cập nhật state ---
        currentState.Update();

        // Reset input jump (nhấn 1 lần thôi)
        IsJumpPress = false;
        IsAttackPress = false;

        if(hp == 1 && !isBlinking)
        {
            StartCoroutine(Blink());
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void setState(State state)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = state;
        currentState.Enter();
    }

    public void TakeDamage(int dam)
    {
        hp -= dam;
        if(hp <= 0)
        {
            Die();
        }
        else
        {
            // Chơi animation Hurt
           // animator.Play("Hurt");
        }
    }

    private void Die()
    {
       Destroy(gameObject);
       GameManager.GameOver();
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPoolingBullet.Instance.GetBullet();
        if (bullet != null)
        {
            bullet.GetComponent<Bullet>().Move(FirePoint.position, facingRight);
        }
        else
        {
            Debug.LogWarning("Pool hết bullet!");
        }
    }

    IEnumerator Blink()
    {
        isBlinking = true;
        while(hp == 1)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkDuration);
        }
        spriteRenderer.enabled = true;
        isBlinking = false;
    }
}