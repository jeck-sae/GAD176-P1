using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : ManagedBehaviour
{
    [SerializeField] float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
