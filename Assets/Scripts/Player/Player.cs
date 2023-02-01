using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Mover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanger;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    public void IncreaceScore()
    {
        _score++;
        ScoreChanger?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;

        ScoreChanger?.Invoke(_score);

        _mover.ResetPosition();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
