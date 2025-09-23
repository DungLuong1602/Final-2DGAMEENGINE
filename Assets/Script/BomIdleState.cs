using UnityEngine;

public class BombIdleState: State
{
    private BomControl bom;
    private float timer;

    public BombIdleState(BomControl bomControl): base(null)
    {
        bom = bomControl;
    }

    public override void Enter()
    {
        timer = bom.explosionDelay;
        bom.animator.Play("BossBulletPrepare");
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            bom.ChangeState(new BombExplosionState(bom));
        }
    }
}
