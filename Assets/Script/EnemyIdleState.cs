using UnityEngine;

public class EnemyIdleState : State
{
    private EnemyControl _enemy;
    public EnemyIdleState(EnemyControl enemy) : base(null)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        _enemy.animator.Play("EnemyIdle");
    }


    public override void Exit()
    {
    }

    public override void Update()
    {
        // Bắn raycast
        Vector2 dir = _enemy.facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(_enemy.rayOrigin.position, dir, _enemy.DetectRange, _enemy.playerLayer);
        Debug.DrawRay(_enemy.rayOrigin.position, dir * _enemy.DetectRange, Color.red);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            _enemy.ChangeState(new EnemyPrepareState(_enemy));
        }
    }
}
