using UnityEngine;

public class EnemyPrepareState : State
{
    private EnemyControl _enemy;
    private float _prepareTime = 0.16f; // Thời gian chuẩn bị tấn công
    private float _timer;

    public EnemyPrepareState(EnemyControl enemy) : base(null)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        _timer = _prepareTime;
        _enemy.animator.Play("EnymyPrepare");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;

        // Nếu player rời khỏi tầm nhìn trong lúc chuẩn bị → quay về Idle
        Vector2 dir = _enemy.facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(_enemy.rayOrigin.position, dir, _enemy.DetectRange, _enemy.playerLayer);
        if (hit.collider == null)
        {
            _enemy.ChangeState(new EnemyPatrolState(_enemy));
            return;
        }

        // Hết thời gian chờ → chuyển sang Attack
        if (_timer <= 0f)
        {
            _enemy.ChangeState(new EnemyAttackState(_enemy));
        }
    }
}
