using UnityEngine;
public class BombObjectPooling : MonoBehaviour
{
    public static BombObjectPooling Instance;
    public GameObject bombPrefab; // Prefab của bom
    public int poolSize = 10; // Kích thước của pool
    private GameObject[] bombPool; // Mảng lưu trữ các bom trong pool


    public void Awake()
    {
        // Thiết lập singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    void Start()
    {
        // Khởi tạo pool
        bombPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bombPool[i] = Instantiate(bombPrefab);
            bombPool[i].SetActive(false); // Vô hiệu hóa bom ban đầu
        }
    }


    public GameObject GetBomb()
    {
        // Tìm bom không hoạt động trong pool và kích hoạt nó
        for (int i = 0; i < poolSize; i++)
        {
            if (!bombPool[i].activeInHierarchy)
            {
                bombPool[i].SetActive(true);
                return bombPool[i];
            }
        }
        // Nếu tất cả bom đều đang hoạt động, có thể mở rộng pool hoặc trả về null
        return null;
    }
}



