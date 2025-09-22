using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerControl player) : base(player) { }
    public override void Enter()
    { 
        _player.animator.Play("Idle");
        _player.rb.linearVelocity = new Vector2(0, _player.rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (Mathf.Abs(_player.InputMove) > 0.1f)
            _player.setState(new RunState(_player));

        if (_player.IsJumpPress && _player.IsGrounded)
            _player.setState(new JumpState(_player));

        if (_player.IsAttackPress)
            _player.setState(new AttackState(_player));
    }
}
