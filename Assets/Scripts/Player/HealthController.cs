using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if( _currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Muerto");
    }
}
