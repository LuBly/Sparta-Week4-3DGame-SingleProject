using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 오브젝트와 상호작용 할 스크립트만 사용
    public PlayerCondition Condition;
    public PlayerMovementController MovementController;
    public PlayerLookController LookController;
    public PlayerEquipmentController equipmentController;

    public ItemData ItemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        Condition = GetComponent<PlayerCondition>();
        MovementController = GetComponent<PlayerMovementController>();
        LookController = GetComponent<PlayerLookController>();
        equipmentController = GetComponent<PlayerEquipmentController>();
    }
}
