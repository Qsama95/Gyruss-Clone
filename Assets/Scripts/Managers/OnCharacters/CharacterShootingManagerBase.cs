using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// for extendability to let enemy shoot
/// </summary>
public class CharacterShootingManagerBase : MonoBehaviour
{
    [SerializeField] private ShootingController _shootingController;
    [SerializeField] private Transform _muzzleTransform;
    public Action ShootingAction;

    protected virtual void Awake()
    {
        RegisterListeners();
    }

    private void Start()
    {
        _shootingController.InitizeBulletPool();
    }

    protected virtual void OnDestroy()
    {
        UnregisterListeners();
    }

    protected virtual void RegisterListeners()
    {
        ShootingAction += OnShootingActionTriggered;
    }

    protected virtual void UnregisterListeners()
    {
        ShootingAction -= OnShootingActionTriggered;
    }

    private void OnShootingActionTriggered()
    {
        _shootingController.ShootBullet(_muzzleTransform.position, transform.up);
    }
}
