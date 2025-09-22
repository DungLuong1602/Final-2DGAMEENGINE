using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerControl player) : base(player) { }


    public override void Enter()
    {
        _player.animator.Play("Jump");
        AudioManager.Instance.PlaySFX("Jump");
        Debug.Log("Entering Jump State");
        _player.rb.linearVelocity = new Vector2(_player.rb.linearVelocity.x, _player.jumpForce);
    }
    

    public override void Exit()
    {

        Debug.Log("Exiting Jump State");
        //_player.animator.SetBool("isJumping", false);
    }

    public override void Update()
    {
        float move = _player.InputMove;
        _player.rb.linearVelocity = new Vector2(move * _player.speed, _player.rb.linearVelocity.y);
        if(_player.rb.linearVelocity.y < 0)
        {
            _player.setState(new FallState(_player));
            return;
        }
        // Double Jump
        if (_player.IsJumpPress && _player.canDoubleJump && !_player.hasDoubleJumped)
        {
            _player.rb.linearVelocity = new Vector2(_player.rb.linearVelocity.x, _player.jumpForce);
            _player.hasDoubleJumped = true;
            _player.animator.Play("Jump");
            AudioManager.Instance.PlaySFX("Jump");
        }
        if (_player.IsAttackPress)
        {
            _player.setState(new AttackState(_player));
        }
    }
}
