using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private CharacterMoveManagerBase _moveManagerBase;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        DetectMoveInput();
        DetectShootInput();
    }

    private void DetectMoveInput()
    {
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            //_moveManagerBase.MovingInput?.Invoke();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //_moveManagerBase.MovingInput?.Invoke();
        }
    }

    private void DetectShootInput()
    {
        if (Input.GetKey(KeyCode.J))
        {
        }
    }
}
