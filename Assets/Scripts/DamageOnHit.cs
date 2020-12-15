using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField]
    private UnitType harmfulTo;

    [SerializeField]
    private int damage = 1;

    private protected bool RegisterHit(Collider other)
    {
        if (other.gameObject.CompareTag(harmfulTo.ToString()))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            return true;
        }

        return false;
    }
}