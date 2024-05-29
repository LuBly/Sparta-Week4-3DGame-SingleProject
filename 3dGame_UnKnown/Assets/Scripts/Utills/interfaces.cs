public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public interface IEquipable
{
    public EquipType GetEquipType();

}