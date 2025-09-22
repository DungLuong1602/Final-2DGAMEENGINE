using UnityEngine;

public class EnemyAttackState : State
{
    private EnemyControl _enemy;
    private float attackCountdown = 1f;
    private float attackTimer;


    public EnemyAttackState(EnemyControl enemy) : base(null)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        attackTimer = attackCountdown;
        _enemy.animator.Play("EnemyAttack");
//_enemy.audioSource.PlayOneShot(_enemy.attackSound);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        attackTimer -= Time.deltaTime;
        // Khi kết thúc animation tấn công, chuyển về trạng thái Idle
        if (attackTimer <= 0f)
        {
            _enemy.animator.Play("EnemyAttack");
            attackTimer = attackCountdown;

        }

        Vector2 dir = _enemy.facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(_enemy.rayOrigin.position, dir, _enemy.DetectRange, _enemy.playerLayer);
        if (hit.collider == null)
        {
            _enemy.ChangeState(new EnemyPatrolState(_enemy));
            return;
        }
    }
}
