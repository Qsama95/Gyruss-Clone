using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootingManagerBase : MonoBehaviour
{
    public Action<Vector2> ShootingAction;

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
        ShootingAction += OnShootingActionStart;
    }

    protected virtual void UnregisterListeners()
    {
        ShootingAction -= OnShootingActionStart;
    }

    private void OnShootingActionStart(Vector2 shootDir)
    {
        // shoot bullet to shoot dir
    }
}
