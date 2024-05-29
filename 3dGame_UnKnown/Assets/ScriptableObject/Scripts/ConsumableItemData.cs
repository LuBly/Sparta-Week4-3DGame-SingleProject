using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Consumable", order = 1)]
public class ConsumableItemData : ItemData
{
    // 효과가 여러개일 수 있다.
    [System.Serializable]
    public class ItemDataConsumable
    {
        public ConsumableType type;
        public float value;
    }

    [Header("ConsumableValue")]
    public ItemDataConsumable[] consumableValues;
}
