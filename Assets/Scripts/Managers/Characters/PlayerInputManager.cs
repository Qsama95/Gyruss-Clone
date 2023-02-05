using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private CharacterMotionManagerBase _moveManager;
    private CharacterShootingManagerBase _shootingManager;

    private void Awake()
    {
        _moveManager = GetComponent<CharacterMotionManagerBase>();
        _shootingManager = GetComponent<CharacterShootingManagerBase>();
    }

    private void Update()
    {
        DetectMotionInput();
        DetectShootInput();
    }

    private void DetectMotionInput()
    {
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            _moveManager.RotateAction?.Invoke(Vector3.zero, -25);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _moveManager.RotateAction?.Invoke(Vector3.zero, 25);
        }
    }

    private void DetectShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shootingManager.ShootingAction?.Invoke();
        }
    }
}
