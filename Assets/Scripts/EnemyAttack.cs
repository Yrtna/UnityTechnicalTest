using System;
using UnityEngine;

public class EnemyAttack : DamageOnHit
{
    private IKillable unit;

    private void Start()
    {
        unit = GetComponent<IKillable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (RegisterHit(other))
        {
            unit?.Die();
        }
    }
}