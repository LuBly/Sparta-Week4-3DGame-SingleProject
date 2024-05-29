using UnityEngine;

public class EquipItemObject : ItemObject, IEquipable
{
    [SerializeField] private EquipItemData equipData;
    private void Awake()
    {
        data = equipData;
    }
    public EquipType GetEquipType()
    {
        return equipData.equipType;
    }
}

