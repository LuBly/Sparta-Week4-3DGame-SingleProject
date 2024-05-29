using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Equipable", order = 2)]
public class EquipItemData : ItemData
{
    [Header("Equip")]
    public GameObject equipPrefab;
    public EquipType equipType;
}