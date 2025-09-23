using UnityEngine;

public class BossAppearState: State
{
    private float appearDuration = 3f; // Thời gian boss xuất hiện
    private float timer;
    private BossControl boss;

    public BossAppearState(BossControl boss): base(null)
    {
        this.boss = boss;
    }


    public override void Enter()
    {
        timer = 0f;
        Debug.Log("Boss is appearing!");
        boss.animator.Play("BossAppear");
        // Play appear animation or effects here
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= appearDuration)
        {
            // Sau khi xuất hiện xong → vào giai đoạn vận công
            boss.ChangeState(new BossPrepareState(boss));
        }
    }

    public override void Exit()
    {
        Debug.Log("Boss has finished appearing.");
        // Cleanup or reset variables if needed
    }
}
