using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterMotionManagerBase))]
public class EnemyBehaviorManager : MonoBehaviour
{
    [Header("Motions")]
    [SerializeField] 
    [Range(-10, 10)] private float _moveInAndOutSpeed;
    [SerializeField]
    [Range(-25, 25)] private float _rotateSpeed;
    [SerializeField]
    [Range(0, 20)] private float _largestDistance;

    private float _initialMoveSpeed;
    private int _moveMultiplier = 1;
    private float _distanceToCenter;

    private CharacterMotionManagerBase _motionManager;

    public float DistanceToCenter { get => _distanceToCenter; set => _distanceToCenter = value; }

    private void Awake()
    {
        _motionManager = GetComponent<CharacterMotionManagerBase>();
    }

    private void Start()
    {
        Init();

        // do orbit motion after every certain delay
        InvokeRepeating(nameof(RandomOrbitMotion), 1, 5);
    }

    private void Init()
    {
        // initilize random rotaion speed and move speed
        _rotateSpeed = Random.Range(15, 25);
        _moveInAndOutSpeed = Random.Range(1, 10);
        _initialMoveSpeed = _moveInAndOutSpeed;

        // start to move to an random dir
        var randomDir = Random.insideUnitSphere;
        randomDir.z = 0;
        transform.DOMove(transform.position + randomDir, 1);
    }

    void Update()
    {
        EnemyMoving();
        EnemyRotating();
        CalculateDistanceToCenter();
    }

    private void EnemyMoving()
    {
        _motionManager.MoveAction?.Invoke(
            (transform.position - Vector3.zero).normalized,
            _moveInAndOutSpeed * _moveMultiplier);
    }

    private void EnemyRotating()
    {
        _motionManager.RotateAction?.Invoke(
            Vector3.zero, 
            _rotateSpeed);
    }

    private void CalculateDistanceToCenter()
    {
        _distanceToCenter = Vector3.Distance(transform.position, Vector3.zero);
        if (_distanceToCenter >= _largestDistance)
        {
            // move towards inside
            _moveMultiplier = -1;
        }
        if (_distanceToCenter <= 0.1f)
        {
            // move towards outside
            _moveMultiplier = 1;
        }
    }

    private void RandomOrbitMotion()
    {
        var randomDuration = Random.Range(3, 10);
        StartCoroutine(nameof(StartOrbitMotion), randomDuration);
    }

    private IEnumerator StartOrbitMotion(float duration)
    {
        _moveInAndOutSpeed = 0;
        yield return new WaitForSeconds(duration);
        _moveInAndOutSpeed = _initialMoveSpeed;
    }
}
