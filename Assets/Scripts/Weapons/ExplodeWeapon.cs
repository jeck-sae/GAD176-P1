using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ExplodeWeapon : Weapon
{
    [SerializeField] GameObject explosionEffectPrefab;

    public float explosionRange;
    public float damage;

    public override void Shoot()
    {
        var hit = Physics2D.CircleCastAll(transform.position, explosionRange, Vector2.zero);
        foreach (var item in hit) 
        { 
            var targetable = item.transform.GetComponent<Targetable>();
            
            if(targetable != null && targetable != owner)
            {
                targetable.Damage(damage);
                Debug.Log(targetable.name + " " + damage);
            }
        }

        // If close to player, screenshake

        var explosionEffect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        owner.Die();
    }
}
