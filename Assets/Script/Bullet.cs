
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private GameObject _bulletParts;

    Transform _tr;
    Vector3 _dir;
    private void Start()
    {
        _tr = Camera.main.transform;

        _dir = _tr.position - transform.position;
    }

    private void Update()
    {
        _rigidbody.velocity = _dir.normalized * _speed;
    }

    private bool _isHit = false;
    private void OnTriggerEnter(Collider other)
    {
        if(_isHit)
        {
            return;
        }

        _isHit = true;
        Destroy(gameObject);

        AudioManager.Instance.PlaySE("BattlePlayerRepel");

        OVRInput.SetControllerVibration(frequency: 0.1f, amplitude: 0.1f);
        Instantiate(_bulletParts);
        Instantiate(_bulletParts);
    }
}
