using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyerChecker : MonoBehaviour
{
    [SerializeField] ScoreController _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score.ChangeScore();
    }
}
