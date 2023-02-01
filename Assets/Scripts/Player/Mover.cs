using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 50f;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _speedRotation;

    private Quaternion _startRotation;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        transform.position = _startPosition;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;

        _maxRotation = Quaternion.Euler(_startRotation.x, _startRotation.y , _maxRotationZ);
        _minRotation = Quaternion.Euler(_startRotation.x, _startRotation.y, _minRotationZ);

        ResetPosition();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector2(_speed, 0);

            transform.rotation = _maxRotation;

            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotation * Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
    }
}
