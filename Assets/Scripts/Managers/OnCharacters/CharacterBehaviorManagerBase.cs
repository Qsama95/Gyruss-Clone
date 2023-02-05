using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CharacterBehaviorManagerBase : MonoBehaviour
{
    [SerializeField] 
    [Range(-10, 10)] private float _moveSpeed;
    [SerializeField]
    [Range(-10, 10)] private float _rotateSpeed;

    private CharacterMotionManagerBase _moveManager;

    private void Awake()
    {
        _moveManager = GetComponent<CharacterMotionManagerBase>();
    }

    private void Start()
    {
        var randomDir = Random.insideUnitSphere;
        randomDir.z = 0;

        _moveManager.MoveAction?.Invoke(
            transform.position + randomDir, 
            _moveSpeed);
    }

    void Update()
    {
        EnemyMoving();
        EnemyRotating();
    }

    private void EnemyMoving()
    {
        _moveManager.MoveAction?.Invoke(
            (transform.position - Vector3.zero).normalized,
            _moveSpeed);
    }

    private void EnemyRotating()
    {
        _moveManager.RotateAction?.Invoke(
            Vector3.zero, 
            _rotateSpeed);
    }
}
