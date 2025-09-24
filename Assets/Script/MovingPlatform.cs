using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 offset = new Vector3(5f, 0f, 0f); // khoảng cách từ A -> B
    public float speed = 2f;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    void Start()
    {
        // Lấy vị trí hiện tại làm Point A
        pointA = transform.position;
        // Point B = A + offset
        pointB = pointA + offset;

        target = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform); // Player thành con của platform
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }

}
