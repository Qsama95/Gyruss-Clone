using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveManagerBase : MonoBehaviour
{
    protected Vector2 _moveDir;

    public Action<Vector2> MoveAction;

    protected virtual void Awake()
    {
        RegisterListeners();
    }

    protected virtual void OnDestroy()
    {
        UnregisterListeners();
    }

    protected virtual void RegisterListeners()
    {
        MoveAction += OnMoveActionStart;
    }

    protected virtual void UnregisterListeners()
    {
        MoveAction -= OnMoveActionStart;
    }

    private void OnMoveActionStart(Vector2 moveDir)
    {
        // move character to move direction
    }
}
