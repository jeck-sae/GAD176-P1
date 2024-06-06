using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public partial class Projectile : ManagedBehaviour
{
    [ReadOnly] public float damage;
    [ReadOnly] public float speed;
    [ReadOnly] public Targetable shotBy;
    public virtual void Initialize(Targetable shotBy, float damage, float speed, float duration)
    {
        this.damage = damage;
        this.speed = speed;
        this.shotBy = shotBy;
        Destroy(gameObject, duration);
    }

    public override void ManagedUpdate()
    {
        float moveby = speed * Time.deltaTime;
        transform.position += transform.right * moveby;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetable = collision.GetComponent<Targetable>();
        if (targetable == null)
        {
            Impact();
            return;
        }

        if (targetable == shotBy)
            return;

        targetable.Damage(damage);
        Impact();
    }

    public void Impact()
    {
        enabled = false;
        Destroy(gameObject);
    }
}