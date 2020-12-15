using UnityEngine;

public class EnemyDeath : Death
{
    [SerializeField]
    public GameObject deathEffect;
    public override void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}