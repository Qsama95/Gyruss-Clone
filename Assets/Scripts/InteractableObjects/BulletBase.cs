using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _delay = 3;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitTarget = collision.GetComponent<IBulletTarget>();
        if (hitTarget != null)
        {
            hitTarget.GetHit(_damage);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(DisableAfterDelay), _delay);
        SetCollisionDetection(true);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        SetCollisionDetection(false);
    }

    private void SetCollisionDetection(bool setActive)
    {
        _rigidBody.simulated = setActive;
        _collider.enabled = setActive;
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
