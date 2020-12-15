using System;
using UnityEngine;

public class PlayerAttack : DamageOnHit
{
    private void OnCollisionEnter(Collision other)
    {
        RegisterHit(other.collider);
    }
}