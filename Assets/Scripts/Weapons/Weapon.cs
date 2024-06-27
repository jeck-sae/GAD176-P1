using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using static UnityEngine.GraphicsBuffer;

public abstract class Weapon : Interactable2D 
{
    public float attackDistance = 3;
    public Unit owner;
    protected SpriteRenderer sr;

    protected override void ManagedInitialize()
    {
        if (owner == null)
        {
            Unit u = GetComponentInParent<Unit>();
            if (u)
            {
                SetOwner(u);
                owner.weapon = this;
            }
        }
        if(sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    public virtual void Reload() { }
    
    public virtual void TryShooting() 
        => Shoot();

    public virtual void Shoot() { }

    public virtual void Drop()
    {
        sr.enabled = true;
        owner = null;
        transform.SetParent(null);
    }

    public virtual void Pickup(Unit unit)
    {
        sr.enabled = false;
        SetOwner(unit);
    }
    protected void SetOwner(Unit unit)
    {
        owner = unit;
        transform.SetParent(owner.transform);
        transform.position = owner.transform.position;
        transform.rotation = owner.transform.rotation;

    }

    protected override void OnCursorSelectStart()
    {
        FindObjectOfType<Player>().PickupWeapon(this);
    }

}
