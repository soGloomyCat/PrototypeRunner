using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerDamage _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts;

    private void Awake()
    {
        _hearts = new List<Heart>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int currentValue = value - _hearts.Count;
            for (int i = 0; i < currentValue; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int currentValue = _hearts.Count - value;
            for (int i = 0; i < currentValue; i++)
            {
                DeleteHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }

    private void DeleteHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
