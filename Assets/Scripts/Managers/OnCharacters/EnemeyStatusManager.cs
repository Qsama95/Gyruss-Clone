using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(EnemyBehaviorManager))]
public class EnemeyStatusManager : MonoBehaviour, IBulletTarget
{
    [SerializeField] private PlayerScoreController _playerScoreController;
    [SerializeField] private int _hp = 10;
    [SerializeField] private int _maxScore = 10;
    [SerializeField] private TextMeshProUGUI _currentScoreTMP;

    private EnemyBehaviorManager _behaviorManager;
    private int _currentScore;

    private void Awake()
    {
        _behaviorManager = GetComponent<EnemyBehaviorManager>();
    }

    private void Update()
    {
        // update score according to the distance to center
        UpdateScoreOnEnemy();
    }

    private void UpdateScoreOnEnemy()
    {
        _currentScore = _playerScoreController.UpdateScoreOnEnemy(
            _maxScore,
            _currentScoreTMP,
            -(int)_behaviorManager.DistanceToCenter);
    }

    private void EnemyDead()
    {
        _playerScoreController.UpdateScore?.Invoke(_currentScore);
        Destroy(gameObject);
    }

    #region Implement Interfaces
    // potential to increase the difficulties
    public void GetHit(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            EnemyDead();
        }
    }
    #endregion
}
