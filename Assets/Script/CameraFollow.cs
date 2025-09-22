using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Kéo Player vào Inspector
    public Vector3 offset;     // Độ lệch (nếu muốn camera không bám sát 100%)

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                player.position.x + offset.x,
                player.position.y + offset.y,
                transform.position.z   // giữ nguyên Z của camera
            );
        }
    }
}
