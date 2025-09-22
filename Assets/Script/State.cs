using UnityEngine;

public abstract class State
{
    protected PlayerControl _player;

    public State(PlayerControl player)
    {
        _player = player;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public abstract void Update();

}
