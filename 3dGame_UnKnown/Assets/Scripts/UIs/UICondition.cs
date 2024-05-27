using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition Health;
    public Condition Stamina;

    private void Start()
    {
        CharacterManager.Instance.Player.Condition.UiCondition = this;
    }
}
