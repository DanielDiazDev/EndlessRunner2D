using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ScoreSystem.OnSpeedSpawnObstacle += ModifySpeed;
    }
    private void OnDestroy()
    {
        ScoreSystem.OnSpeedSpawnObstacle -= ModifySpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.left * _speed;
    }
    public void ModifySpeed()
    {
        _speed += 0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(1);
                ServiceLocator.Instance.GetService<SoundSystem>().PlaySound(0);
            }
            Destroy(gameObject);
        }
    }
}
