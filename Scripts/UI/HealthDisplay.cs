using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerDamage _palyer;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        _palyer.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _palyer.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthDisplay.text = health.ToString();
    }
}
