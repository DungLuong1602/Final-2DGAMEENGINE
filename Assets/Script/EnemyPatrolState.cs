using UnityEngine;

public class EnemyPatrolState : State
{
    private bool movingRight = true;
    private EnemyControl _enemy;
    public EnemyPatrolState(EnemyControl enemy) : base(null) 
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        Debug.Log("Enemy start patrol");
        _enemy.animator.Play("EnemyIdle");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        // Phát hiện player
        if (_enemy.DetectPlayer())
        {
            _enemy.ChangeState(new EnemyPrepareState(_enemy));
            return;
        }

        // Di chuyển qua lại
        if (_enemy.facingRight)
        {
            _enemy.transform.position += Vector3.right * _enemy.moveSpeed * Time.deltaTime;
            if (_enemy.transform.position.x >= _enemy.rightPoint.x)
            {
                _enemy.Flip();
            }
        }
        else
        {
            _enemy.transform.position += Vector3.left * _enemy.moveSpeed * Time.deltaTime;
            if (_enemy.transform.position.x <= _enemy.leftPoint.x)
            {
                _enemy.Flip();
            }
        }
    }
}
