using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Giảm máu player
            PlayerControl playerHealth = other.GetComponent<PlayerControl>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(3); // Giảm 1 máu
            }
        }
    }
}
