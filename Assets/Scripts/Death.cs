using UnityEngine;

public class Death : MonoBehaviour, IKillable
{
    public virtual void Die()
    {
        Debug.Log("UnitDeath");
    }
}