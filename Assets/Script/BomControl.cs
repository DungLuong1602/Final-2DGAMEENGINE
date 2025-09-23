using UnityEngine;

public class BomControl : MonoBehaviour
{
    public Animator animator;
    public float explosionDelay = 3f; // Delay before explosion in seconds
    public float explosionDurations = 0.5f; // Radius of the explosion effect

    [HideInInspector] public State currentState;



    void OnEnable()
    {
        ChangeState(new BombIdleState(this));
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // Gọi khi nổ xong để trả về pool
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
