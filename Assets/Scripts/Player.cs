using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    
    void Start()
    {

    }

    public override void ManagedUpdate()
    {

        base.ManagedUpdate();
    }

    public override void Die()
    {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
    }
}
