using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : ManagedBehaviour
{
    Unit unit;
    Vector2 m_movement;
    public float movementSpeed;

    protected override void ManagedInitialize()
    {
        unit = GetComponent<Unit>();
    }

    public override void ManagedUpdate()
    {
        m_movement.x = Input.GetAxis("Horizontal");
        m_movement.y = Input.GetAxis("Vertical");

        unit.MoveBy(m_movement.normalized * movementSpeed * Time.deltaTime);

        if (Input.GetButton("Fire1"))
            unit.TryAttacking();

        if(Input.GetKeyDown(KeyCode.R))
            unit.weapon.Reload();
    }
}
