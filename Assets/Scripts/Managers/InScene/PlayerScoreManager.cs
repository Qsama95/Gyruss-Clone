using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerScoreController _playerScoreController;

    [SerializeField] private TextMeshProUGUI _currentScoreTMP;

    private int _currentScore;

    // Start is called before the first frame update
    private void Awake()
    {
        RegisterListeners();
    }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        _playerScoreController.UpdateScore += OnUpdateScore;
    }

    private void UnregisterListeners()
    {
        _playerScoreController.UpdateScore -= OnUpdateScore;
    }

    private void OnUpdateScore(int score)
    {
        _currentScore = _playerScoreController.UpdateScoreOnScreen(
            _currentScore,
            _currentScoreTMP,
            score);
    }
}
