using UnityEngine;

public class AttackState : State
{
    private float _attackDuration = 0.2f; // thời gian animation bắn
    private float _timer;
    public AttackState(PlayerControl player) : base(player) { }

    public override void Enter()
    {
        _player.animator.Play("Shoot");
        AudioManager.Instance.PlaySFX("Shoot");
        _player.Shoot();
        Debug.Log("Entering Attack State");
        //_player.animator.SetBool("isAttacking", true);
        _player.rb.linearVelocity = new Vector2(0, _player.rb.linearVelocity.y);
        _timer = _attackDuration;
    }

    public override void Exit()
    {
        _player.IsAttackPress = false; // reset input
    }
    public override void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            if (Mathf.Abs(_player.InputMove) > 0.1f)
                _player.setState(new RunState(_player));

            else if (_player.IsJumpPress && _player.IsGrounded)
                _player.setState(new JumpState(_player));
            else
                _player.setState(new IdleState(_player));
        }
    }
}
