using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int Damage;
    public float DamageRate;

    private List<IDamagable> m_damageObjects = new List<IDamagable>();
    private Coroutine damageCoroutine;

    private void Start()
    {
        if (damageCoroutine != null)
            StopCoroutine(damageCoroutine);

        damageCoroutine = StartCoroutine(DealDamage(DamageRate));
    }

    IEnumerator DealDamage(float damageRate)
    {
        while (true)
        {
            foreach (IDamagable damageObject in m_damageObjects)
            {
                damageObject.TakePhysicalDamage(Damage);
            }

            yield return new WaitForSecondsRealtime(damageRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            m_damageObjects.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            m_damageObjects.Add(damagable);
        }
    }
}
