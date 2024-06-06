using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] GameObject projectilePrefab;

    public float damage = 5;
    public float attackSpeed = 2;
    public float projectileSpeed = 5;
    public float projectileSpeedVariation = 1;
    public float projectileDirectionVariation = 0;
    public float projectileLifetime = 3;
    public int projectilesPerShot = 1;

    public int maxAmmo = 6;


    [DisableInEditorMode] public int currentAmmo;
    protected float nextShotMinTime = 0;
    protected bool isReloading;

    public override void Reload()
    {
        //add animation
        isReloading = true;
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public override void TryShooting(Unit shooter)
    {
        if(nextShotMinTime <= Time.time) 
        {
            Shoot(shooter);
            nextShotMinTime = Time.time + attackSpeed;
        }
    }
    

    public override void Shoot(Unit shooter)
    {
        if(currentAmmo <= 0)
        {
            Reload();
            return;
        }

        if(isReloading && currentAmmo > 0) 
        { 
            //Stop reloading
        }

        SpawnProjectile(shooter);
        currentAmmo--;
    }

    

    protected virtual void SpawnProjectile(Unit shooter)
    {
        for(int i = 0; i < projectilesPerShot; i++)
        {
            var go = Instantiate(projectilePrefab, transform.position, GetProjectileDirection());
            var proj = go.GetComponent<Projectile>();
            proj.Initialize(shooter, damage, GetProjectileSpeed(), projectileLifetime);
        }
    }

    protected float GetProjectileSpeed()
    {
        return projectileSpeed + Random.Range(0, projectileSpeedVariation) - projectileSpeedVariation / 2;
    }

    protected Quaternion GetProjectileDirection()
    {
        var variation = Random.Range(0, projectileDirectionVariation) - projectileDirectionVariation / 2;
        return Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * variation);
    }
}
