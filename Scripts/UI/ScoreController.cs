using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int _score;
    private Text _text;

    private void Awake()
    {
        _score = 0;
        _text = GetComponent<Text>();
        _text.text = $"—чет - {_score}";
    }

    public void ChangeScore()
    {
        _score++;
        _text.text = $"—чет - {_score}";
    }
}
