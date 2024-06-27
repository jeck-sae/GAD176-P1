using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : Targetable
{
    public Weapon weapon;
    public Targetable target;

    public event Action WeaponDropped;

    protected Rigidbody2D m_rigidbody;

    protected override void ManagedInitialize()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        if(!weapon)
        {
            weapon = GetComponentInChildren<Weapon>();
        }    

        base.ManagedInitialize();
    }
    public override void ManagedUpdate()
    {
        if (target)
            LookAt(target.transform.position);
    }

    public void MoveBy(Vector2 movement)
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);

        m_rigidbody.MovePosition(currentPos + movement);
    }

    public virtual void TryAttacking()
    {
        weapon.TryAttacking();
    }

    public void LookAt(Vector2 target)
    {
        Vector2 lookDirection = target - (Vector2)transform.position;
        transform.right = lookDirection;
    }

    public void PickupWeapon(Weapon newWeapon)
    {
        if(weapon == newWeapon) 
            return;
        
        if(weapon != null)
            DropWeapon();

        newWeapon.SetEquipped(this);
        weapon = newWeapon;
    }

    public void DropWeapon()
    {
        WeaponDropped?.Invoke();
        weapon = null;
    }
    /*public void ModifyHealth(float amount)
    {
        if (amount <= 0)
            Damage(amount);

        Heal(amount);
    }
    public void Heal(float amount)
    {
        if (isDead)
            return;

        if (amount <= 0)
            return;

        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }*/

}
