using UnityEngine;

public class Death : MonoBehaviour, IKillable
{
    public virtual void Die()
    {
        // TODO create UnityEvent for player death
        GameObject.FindWithTag("UIManager").GetComponent<MenuManager>().GameOver();
    }
}