using UnityEngine;

public class BossControl : MonoBehaviour
{
    [HideInInspector] public State currentState;
    public Animator animator;
    public float SkillDuration = 10f;

    // Phạm vi phòng để random bomb
    public float roomMinX, roomMaxX;
    public float roomMinY, roomMaxY;

    // Số lượng bomb mỗi đợt
    public int bombsPerWave = 5;
    private void Start()
    {
        currentState = new BossAppearState(this);
        currentState.Enter();
    }

    void Update()
    {
        currentState.Update();
        //SkillDuration -= Time.deltaTime;
        //if (SkillDuration <= 0f)
        //{
        //    // Sau khi thời gian kỹ năng kết thúc, chuyển về trạng thái chuẩn bị tấn công
        //    ChangeState(new BossPrepareState(this));
        //    SkillDuration = 10f; // Reset lại thời gian kỹ năng
        //}
    }

    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // ✅ Hàm spawn bomb – gọi từ state
    public void SpawnBombWave()
    {
        for (int i = 0; i < 5; i++) // ví dụ 5 quả/lần
        {
            GameObject bomb = BombObjectPooling.Instance.GetBomb();
            if (bomb != null)
            {
                // Random vị trí trong phòng boss
                float x = Random.Range(roomMinX, roomMaxX);
                float y = Random.Range(roomMinY, roomMaxY);
                bomb.transform.position = new Vector3(x, y, 0f);
            }
            else
            {
                Debug.LogWarning("⚠ Hết bomb trong pool!");
            }
        }
    }
}


