using UnityEngine;

public class BomExplosionState: State
{
    private BomControl bom;
    private float timer;

    public BomExplosionState(BomControl bomControl): base(null)
    {
        bom = bomControl;
    }

    public override void Enter()
    {
        timer = bom.explosionDurations;
        bom.animator.Play("BossBulletExplosion");
        // Play explosion sound effect
        //AudioManager.Instance.PlaySound("ExplosionSound");
        // Enable the explosion collider to deal damage
        // Optionally, you can instantiate explosion effects here
        // Instantiate(bom.explosionEffectPrefab, bom.transform.position, Quaternion.identity);
    }


    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // After explosion duration, deactivate the bomb
            bom.Deactivate();
        }
    }
}
