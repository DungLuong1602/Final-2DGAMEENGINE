using UnityEngine;

public class BossAttackState: State
{
    private float timer;
    private float attackDuration = 6f;
    private float spawnInterval = 1f;
    private float spawnTimer;
    private BossControl boss;
    
    
    public BossAttackState(BossControl boss): base(null)
    {
        this.boss = boss;
    }

    public override void Enter()
    {
        timer = 0f;
        spawnTimer = 0f;
        Debug.Log("Boss is preparing to attack!");
        boss.animator.Play("BossAttack");
        // Play pre-attack animation or effects here
    }

    public override void Exit() { }

    public override void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

       if (spawnTimer >= spawnInterval)
       {
           spawnTimer = 0f;
                //attackLogic.DoExplosion();   // ✅ Gọi logic tấn côn
           boss.SpawnBombWave(); // ✅ Gọi hàm spawn bomb từ BossControl
        }
       if (timer >= attackDuration)
        {
            boss.ChangeState(new BossPrepareState(boss));
        }
    }
}
