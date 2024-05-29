using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData data;
    public string GetInteractPrompt()
    {
        string promptStr = $"{data.displayName}\n{data.description}";
        return promptStr;
    }


    // 상호 작용했을 때 해당 아이템을 땅에서 삭제 -> Inventory에 추가
    public void OnInteract()
    {
        CharacterManager.Instance.Player.ItemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}

