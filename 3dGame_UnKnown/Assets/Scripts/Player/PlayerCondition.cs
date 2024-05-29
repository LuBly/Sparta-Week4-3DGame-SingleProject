using System;
using System.Collections;
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

    public event Action OnTakeDamage;
    
    Coroutine staminaCoroutine, healthCoroutine;

    private void Update()
    {
        stamina.Add(stamina.RegenRate * Time.deltaTime);
    }

    public void UseItem(ConsumableItemData consumableItemData)
    {
        foreach (ConsumableItemDataDetail itemData in consumableItemData.consumableValues)
        {
            switch (itemData.type)
            {
                case ConsumableType.Stamina:
                    if (staminaCoroutine != null) 
                    {
                        StopCoroutine(staminaCoroutine);
                    }
                    staminaCoroutine = StartCoroutine(AddStamina(itemData));
                    break;

                case ConsumableType.Health:
                    if(healthCoroutine != null)
                    {
                        StopCoroutine(healthCoroutine);
                    }
                    healthCoroutine = StartCoroutine(AddHealth(itemData));
                    break;
            }
        }
    }

    IEnumerator AddStamina(ConsumableItemDataDetail itemData)
    {
        int count = 0;
        while(count < itemData.activeCount)
        {
            stamina.Add(itemData.value);
            count++;
            yield return new WaitForSecondsRealtime(itemData.activeDelay);
        }
    }

    IEnumerator AddHealth(ConsumableItemDataDetail itemData)
    {
        int count = 0;
        while (count < itemData.activeCount)
        {
            health.Add(itemData.value);
            count++;
            yield return new WaitForSecondsRealtime(itemData.activeDelay);
        }
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
        OnTakeDamage?.Invoke();
    }
}
