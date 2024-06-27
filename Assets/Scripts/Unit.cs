using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : Targetable
{
    public float movementSpeed;
    public Weapon weapon;

    public Targetable target;

    Rigidbody2D m_rigidbody;

    protected override void ManagedInitialize()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        base.ManagedInitialize();
    }
    public override void ManagedUpdate()
    {
        if (target)
            LookAt(target.transform.position);
    }

    public void MoveBy(Vector2 movement, bool multiplyBySpeed = true)
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);

        if (multiplyBySpeed)
            movement *= movementSpeed;

        m_rigidbody.MovePosition(currentPos + movement);
    }

    public virtual void Shoot()
    {
        weapon.TryShooting();
    }

    public void LookAt(Vector3 target)
    {
        Vector2 lookDirection = target - transform.position;
        transform.right = lookDirection;
    }

    public void PickupWeapon(Weapon newWeapon)
    {
        if(weapon == newWeapon) 
            return;
        
        if(weapon != null)
            DropWeapon();

        newWeapon.Pickup(this);
        weapon = newWeapon;
    }

    public void DropWeapon()
    {
        weapon.Drop();
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
