public class ConsumableObject : ItemObject
{
    private ConsumableItemData consumableItemData;
    private void Start()
    {
        consumableItemData = data as ConsumableItemData;
    }

    protected override void UseItem()
    {
        if (consumableItemData == null) return;
        CharacterManager.Instance.Player.Condition.UseItem(consumableItemData);
    }
}
