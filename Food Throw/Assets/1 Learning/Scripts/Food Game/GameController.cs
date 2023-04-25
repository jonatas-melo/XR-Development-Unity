using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshPro timeDisplay;
    [SerializeField] private TextMeshPro scoreDisplay;
    [SerializeField] private float gameLength;

    private bool _isInProgress;
    private float _timer;
    private int _currentScore;

    // Update is called once per frame
    void Update()
    {
        if (!_isInProgress)
        {
            return;
        }

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _isInProgress = false;
            timeDisplay.text = "00.00";
        }
        else
        {
            timeDisplay.text = _timer.ToString("00.00");
        }
        
        scoreDisplay.text = _currentScore.ToString();
    }

    public void ResetGame()
    {
        _timer = gameLength;
        _currentScore = 0;
        _isInProgress = false;
    }

    public void AddScore()
    {
        if (_isInProgress)
        {
            _currentScore++;
        }
    }
}
