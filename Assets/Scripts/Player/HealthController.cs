using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth;
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }
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
        _player.OnDeath();
    }
}
