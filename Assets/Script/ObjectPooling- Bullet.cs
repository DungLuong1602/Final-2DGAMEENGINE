using UnityEngine;

public class ObjectPoolingBullet : MonoBehaviour
{
    public static ObjectPoolingBullet Instance;
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private GameObject[] bullets;



    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Khởi tạo pool
        bullets = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        Debug.LogWarning("⚠ Pool hết bullet!");
        return null; // nếu hết bullet → null (hoặc có thể mở rộng pool)
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
