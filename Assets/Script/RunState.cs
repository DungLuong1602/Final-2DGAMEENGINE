using System.Runtime.CompilerServices;
using UnityEngine;

public class RunState : State
{
    public RunState(PlayerControl player) : base(player) { }


    public override void Enter()
    {
        _player.animator.Play("Run");
        Debug.Log("Entering Run State");
        AudioManager.Instance.PlayLoop("Walk");
        //_player.animator.SetBool("isRunning", true);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Run State");
        AudioManager.Instance.StopLoop();
        //_player.animator.SetBool("isRunning", false);
    }

    public override void Update()
    {
        float move = _player.InputMove;
    
        _player.rb.linearVelocity = new Vector2(move * _player.speed, _player.rb.linearVelocity.y);

        if (Mathf.Abs(move) < 0.1f)
        {
            _player.setState(new IdleState(_player));
        }
        if(_player.IsJumpPress && _player.IsGrounded)
        {
            _player.setState(new JumpState(_player));
        }

        if(_player.IsAttackPress)
        {
            _player.setState(new AttackState(_player));
        }
    }
}
