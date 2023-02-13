using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "PlayerScoreController", menuName = "Controllers/PlayerScoreController")]
public class PlayerScoreController : ScriptableObject
{
    public Action<int> UpdateScore;

    /// <summary>
    /// update score on game screen
    /// </summary>
    /// <param name="currentScore"></param>
    /// <param name="scoreTMP"></param>
    /// <param name="scoreToAdd"></param>
    /// <returns></returns>
    public int UpdateScoreOnScreen(
        int currentScore, 
        TextMeshProUGUI scoreTMP, 
        int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreTMP.text = currentScore.ToString();
        return currentScore;
    }

    /// <summary>
    /// update score value on enemy
    /// </summary>
    /// <param name="maxScore"></param>
    /// <param name="scoreTMP"></param>
    /// <param name="scoreToAdd"></param>
    /// <returns></returns>
    public int UpdateScoreOnEnemy(
        int maxScore,
        TextMeshProUGUI scoreTMP,
        int scoreToAdd)
    {
        maxScore += scoreToAdd;
        scoreTMP.text = maxScore.ToString();
        return maxScore;
    }
}
