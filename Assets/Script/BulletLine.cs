using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BulletLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _redLineRenderer;
    [SerializeField]
    private LineRenderer _bulletLineRederer;
    [SerializeField]
    private LayerMask _layerMask;

    Transform _tr;
    Vector3 _target;
    private void Start()
    {
        _tr = Camera.main.transform;
        Vector3 _trPosition = _tr.position;

        _target = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(0.5f, 1.25f), 1);
        Vector3[] positions = { _target, transform.position };
        _redLineRenderer.SetPositions(positions);
    }

    Vector3 _hitPosition;
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, _target, out hit, _layerMask))
        {
            _hitPosition = hit.transform.position;
        }
    }

    private void Hit()
    {
        _redLineRenderer.enabled = false;
    }

    private void DrawBulletLine()
    {

    }
}
