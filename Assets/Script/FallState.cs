using UnityEngine;

public class FallState : State
{
    public FallState(PlayerControl player) : base(player) { }

    public override void Enter()
    {
        _player.animator.Play("Fall");
        Debug.Log("Entering Fall State");
        //_player.animator.SetBool("isFalling", true);
    }
    public override void Exit()
    {
        base.Exit();
        AudioManager.Instance.PlaySFX("Walk");
    }


    public override void Update()
    {
        float move = _player.InputMove;
        _player.rb.linearVelocity = new Vector2(move * _player.speed, _player.rb.linearVelocity.y);
        // Nếu chạm đất → Idle hoặc Run
        if (_player.IsGrounded)
        {
            if (Mathf.Abs(move) > 0.1f)
                _player.setState(new RunState(_player));
            else
                _player.setState(new IdleState(_player));
        }

        // Nếu bắn khi rơi
        if (_player.IsAttackPress)
        {
            _player.setState(new AttackState(_player));
        }
    }
}
