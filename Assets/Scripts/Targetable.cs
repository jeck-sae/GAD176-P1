using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Targetable : ManagedBehaviour
{
    [DisableInEditorMode] public float currentHealth;
    public float maxHealth = 100;
    public bool isDead;
    public bool isVulnerable = true;


    public UnityEvent OnDied;
    public UnityEvent OnDamaged;

    protected override void ManagedInitialize()
    {
        currentHealth = maxHealth;
    }


    public void Damage(float amount)
    {
        if (isDead || !isVulnerable)
            return;

        currentHealth -= amount;
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDied?.Invoke();
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
