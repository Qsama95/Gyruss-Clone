using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMotionManagerBase : MonoBehaviour
{
    [SerializeField] private MotionController _motionController;
    public Action<Vector3, float> MoveAction;
    public Action<Vector3, float> RotateAction;

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
        RotateAction += OnRotateActionStart;
    }

    protected virtual void UnregisterListeners()
    {
        MoveAction += OnMoveActionStart;
        RotateAction -= OnRotateActionStart;
    }

    private void OnMoveActionStart(Vector3 moveDir, float speed)
    {
        // move character to move direction
        _motionController.MoveCharacterTowards(transform, moveDir, speed);
    }

    private void OnRotateActionStart(Vector3 rotateCenter, float speed)
    {
        // move character to move direction
        _motionController.RotateCharacterAround(transform, rotateCenter, speed);
    }
}
