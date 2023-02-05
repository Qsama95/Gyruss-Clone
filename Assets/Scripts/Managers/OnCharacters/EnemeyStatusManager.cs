using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemeyStatusManager : MonoBehaviour, IBulletTarget
{
    [SerializeField] private PlayerScoreController _playerScoreController;
    [SerializeField] private int _hp = 10;
    [SerializeField] private int _maxScore = 10;
    [SerializeField] private TextMeshProUGUI _currentScoreTMP;

    private EnemyBehaviorManager _behaviorController;
    private int _score;

    private void Awake()
    {
        _behaviorController = GetComponent<EnemyBehaviorManager>();
    }

    private void Update()
    {
        // update score according to the distance to center
        _score = _maxScore - (int)_behaviorController.DistanceToCenter;
        _currentScoreTMP.text = _score.ToString();
    }

    // potential to increase the difficulties
    public void GetHit(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        _playerScoreController.UpdateScore?.Invoke(_score);
        Destroy(gameObject);
    }
}
