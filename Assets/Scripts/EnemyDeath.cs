using System;
using UnityEngine;

public class EnemyDeath : Death
{
    [SerializeField]
    public GameObject deathEffect;

    [SerializeField]
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("UIManager").GetComponent<ScoreManager>();
    }

    public override void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        scoreManager.AddScore(1);
        Destroy(gameObject);
    }
}