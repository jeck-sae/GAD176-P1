using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using static UnityEngine.GraphicsBuffer;

//TODO turn into ScriptableObject
public abstract class Weapon : ManagedBehaviour 
{
    public float attackDistance = 3;

    public virtual void Reload() { }
    
    public virtual void TryShooting(Unit shooter) 
        => Shoot(shooter);

    public virtual void Shoot(Unit shooter) { }
}
