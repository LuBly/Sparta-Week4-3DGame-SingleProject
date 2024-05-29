using UnityEngine;

// 효과가 여러개일 수 있다.
[System.Serializable]
public class ConsumableItemDataDetail
{
    public ConsumableType type;
    public float activeDelay;   // 몇 초 간격으로
    public int activeCount;     // 몇 번?
    public float value;         // 얼마만큼의 value를 올려줄 것인가?
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Consumable", order = 1)]
public class ConsumableItemData : ItemData
{
    [Header("ConsumableValue")]
    public ConsumableItemDataDetail[] consumableValues;
}
