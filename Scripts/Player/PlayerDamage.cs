using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction PlayerDeath;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        Debug.Log(_health);
        HealthChanged.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        PlayerDeath?.Invoke();
        Time.timeScale = 0;
    }
}
