using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 2f;
    private float timer;
    private int direction = 1; // 1: right, -1: left

    void OnEnable()
    {
        timer = lifeTime;
    }
    private void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // Gọi trả về pool
            ObjectPoolingBullet.Instance.ReturnBullet(gameObject);
        }
    }
    public void Move(Vector3 startPos,bool facingRight)
    {
       transform.position = startPos;
       direction = facingRight ? 1 : -1;
        // flip asset bullet
       Vector3 scale = transform.localScale;
       scale.x = Mathf.Abs(scale.x) * direction;
       transform.localScale = scale;

       gameObject.SetActive(true);
    }
}
