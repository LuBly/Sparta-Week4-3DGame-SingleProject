using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 오브젝트와 상호작용 할 스크립트만 사용
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}
