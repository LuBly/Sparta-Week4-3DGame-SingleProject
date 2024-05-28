using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Consumable", order = 1)]
public class ConsumableItemData : ItemData
{
    [System.Serializable]
    public class ItemDataConsumable
    {
        public ConsumableType type;
        public float value;
    }

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
