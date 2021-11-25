using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    [SerializeField] private PlayerDamage _player;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.PlayerDeath += OnDied;
        _restart.onClick.AddListener(OnRestartButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.PlayerDeath -= OnDied;
        _restart.onClick.RemoveListener(OnRestartButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnDied()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
