using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 오브젝트와 상호작용 할 스크립트만 사용
    public PlayerCondition Condition;
    public PlayerMovementController MovementController;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        Condition = GetComponent<PlayerCondition>();
        MovementController = GetComponent<PlayerMovementController>();
    }
}
