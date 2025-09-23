using UnityEngine;

public class BossPrepareState: State
{
    private BossControl boss;
    private float prepareDuration = 0.15f; // Thời gian chuẩn bị tấn công
    private float timer;


    public BossPrepareState(BossControl boss): base(null)
    {
        this.boss = boss;
    }

    public override void Enter()
    {
        timer = prepareDuration;
        Debug.Log("Boss is preparing to attack!");
        boss.animator.Play("BossPrepare");
        // Play pre-attack animation or effects here
    }


    public override void Exit() { }
    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            boss.ChangeState(new BossAttackState(boss)); // Chuyển sang trạng thái tấn công
        }
    }
}
