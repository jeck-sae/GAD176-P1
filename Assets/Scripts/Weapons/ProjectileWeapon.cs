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

    public float reloadSpeed = 1;
    public int maxAmmo = 6;


    [DisableInEditorMode] public int currentAmmo;
    protected float nextShotMinTime = 0;
    protected bool isReloading;

    protected override void ManagedInitialize()
    {
        currentAmmo = maxAmmo;
        base.ManagedInitialize();
    }

    public override void Reload()
    {
        if (currentAmmo == maxAmmo)
            return;
        //add animation
        isReloading = true;
        CustomCoroutine.WaitThenExecute(reloadSpeed, DoReload);
    }

    protected void DoReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public override void TryShooting()
    {
        if (currentAmmo <= 0)
        {
            Reload();
            return;
        }
        if (isReloading)
            return;

        if (nextShotMinTime <= Time.time) 
        {
            Shoot();
            nextShotMinTime = Time.time + attackSpeed;
        }
    }
    

    public override void Shoot()
    {
        SpawnProjectile(owner);
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
