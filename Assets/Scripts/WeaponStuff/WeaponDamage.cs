using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private List<Collider> alreadyCollidedWith =  new List<Collider>();

    private int damage;
    private float knockback;

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent<HealthSystem>(out HealthSystem health)) 
        {
            health.DealDamage(damage);
        }

        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReciever))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReciever.AddForce(direction * knockback);
        }

    }

    public void SetAttack(int damage, float knockback)
    {

        this.damage = damage;
        this.knockback = knockback;
    }

}
