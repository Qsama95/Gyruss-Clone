using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ShootingController", menuName = "Controllers/ShootingController")]
public class ShootingController : ScriptableObject
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _amount;

    private Queue<GameObject> _bulletPool = new Queue<GameObject>();

    /// <summary>
    /// prepare the bullet pool
    /// </summary>
    public void InitizeBulletPool()
    {
        for (int i = 0; i < _amount; i++)
        {
            var newBullet = Instantiate(_bulletPrefab);
            newBullet.SetActive(false);

            _bulletPool.Enqueue(newBullet);
        }
    }

    /// <summary>
    /// shoot bullet towards given direction
    /// </summary>
    /// /// <param name="startPos"></param>
    /// <param name="dir"></param>
    public void ShootBullet(Vector3 startPos, Vector3 dir)
    {
        var bulletToShoot = _bulletPool.Dequeue();
        bulletToShoot.transform.position = startPos;
        bulletToShoot.SetActive(true);
        bulletToShoot.GetComponent<Rigidbody2D>().AddForce(dir * _bulletSpeed);
        bulletToShoot.transform.right = dir;
        _bulletPool.Enqueue(bulletToShoot);
    }
}
