using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MotionController", menuName = "Controllers/MotionController")]
public class MotionController : ScriptableObject    
{
    /// <summary>
    /// move character on a given direction with a certain speed
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="moveDir"></param>
    /// <param name="speed"></param>
    public void MoveCharacterTowards(Transform transform, Vector3 moveDir, float speed)
    {
        // move character to move direction
        transform.position += moveDir * speed * Time.deltaTime;
    }

    /// <summary>
    /// rotate character around a given center with a certain speed
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="rotateCenter"></param>
    /// <param name="speed"></param>
    public void RotateCharacterAround(Transform transform, Vector3 rotateCenter, float speed)
    {
        // move character to move direction
        transform.RotateAround(rotateCenter, Vector3.forward, speed * Time.deltaTime);
    }
}
