public class EquipObject : ItemObject
{
    private EquipItemData equipItemData;
    private void Start()
    {
        equipItemData = data as EquipItemData;
    }

    protected override void UseItem()
    {
        if (equipItemData == null) return;
        CharacterManager.Instance.Player.equipmentController.EquipItem(equipItemData);
    }
}



