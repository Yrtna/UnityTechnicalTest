using UnityEngine;

[RequireComponent(typeof(Death))]
public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;

    private IKillable unit;
    
    void Start()
    {
        currentHealth = maxHealth;
        unit = GetComponent<IKillable>();
    }

    public void TakeDamage(int qty)
    {
        currentHealth -= qty;
        if (currentHealth > 0) return;
        currentHealth = 0;
        unit?.Die();
    }
}
