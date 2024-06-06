using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Unit
{
    public float visionRange = 10;
    public float rotationSpeedWhenIdle = 10;
    public float chaseSpeed = 3.5f;

    private void Start()
    {
        
    }

    public override void ManagedUpdate()
    {
        SearchTarget();

        if (target)
        {
            LookAt(target.transform.position);

            float distance = Vector3.Distance(target.transform.position, transform.position);
            if(distance < weapon.attackDistance)
            {
                Shoot();
            }
            else
            {
                ChaseTarget();
            }
        }
        else
        {
            Idle();
        }

        //idle
        //chase
        //shoot
    }


    public void SearchTarget()
    {
        if (target && IsValidTarget(target))
            return;
        target = null;

        // TEMPORARY ===========================
        var player = FindObjectOfType<Player>();
        if(player && IsValidTarget(player)) 
            target = player;
    }

    protected bool IsValidTarget(Targetable target)
    {
        if (!target) return false;
        float distance = Vector3.Distance(target.transform.position, transform.position);
        return distance < visionRange;
    }

    public void Idle()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * Time.deltaTime * rotationSpeedWhenIdle);
    }

    public void ChaseTarget()
    {
        var direction = (target.transform.position - transform.position).normalized;
        MoveBy(direction * chaseSpeed * Time.deltaTime);
    }


}
