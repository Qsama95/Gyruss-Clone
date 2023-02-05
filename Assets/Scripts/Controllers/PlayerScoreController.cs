using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScoreController", menuName = "Controllers/PlayerScoreController")]
public class PlayerScoreController : ScriptableObject
{
    public Action<int> UpdateScore;
}
