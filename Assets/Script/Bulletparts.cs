using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bulletparts : MonoBehaviour
{
    [SerializeField]
    private float _power = 25f;
    [SerializeField]
    private Rigidbody _rigidbody;

    private void Start()
    {
        Destroy(gameObject, 1f);

        Vector3 dir = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        _rigidbody.AddForce(dir, ForceMode.Impulse);
    }
}
