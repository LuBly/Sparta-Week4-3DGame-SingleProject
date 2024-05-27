using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition UiCondition;

    Condition health { get { return UiCondition.Health; } }
    Condition stamina { get { return UiCondition.Stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {

    }

    public bool UseStamina(float amount)
    {
        if(stamina.CurValue - amount > 0)
        {
            stamina.Subtract(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}
