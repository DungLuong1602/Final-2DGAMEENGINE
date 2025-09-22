using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float DetectRange = 5f;
    public LayerMask playerLayer;
    public Animator animator;
    public Transform rayOrigin;
    public bool facingRight = true;
    [HideInInspector] public State currentState;

    public float moveSpeed = 2f;
    public Vector2 leftPoint ;
    public Vector2 rightPoint ;
    public float patrolRange = 5f;  // Khoảng cách đi tuần



    private void Start()
    {
        leftPoint = transform.position;
        rightPoint = leftPoint + new Vector2(patrolRange, 0);
        currentState = new EnemyPatrolState(this);
        currentState.Enter();
    }
    
    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(State newState)
    {
        if(currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // Hàm phát hiện player
    public bool DetectPlayer()
    {
        Vector2 dir = facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, dir, DetectRange, playerLayer);
        return hit.collider != null;
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
