using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -5);
    [SerializeField] private float _rotationSpeed = 3f;
    [SerializeField] private float _topClamp = 60f;
    [SerializeField] private float _bottomClamp = -30f;

    private float _horizontal;
    private float _vertical;
    private Vector3 _distanceFromTarget = Vector3.up * 2;

    void LateUpdate()
    {
        _horizontal += Input.GetAxis("Mouse X") * _rotationSpeed;
        _vertical -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        _vertical = Mathf.Clamp(_vertical, _bottomClamp, _topClamp);

        Quaternion rotation = Quaternion.Euler(_vertical, _horizontal, 0);
        Vector3 desiredPosition = _target.position + rotation * _offset;
        transform.position = desiredPosition;
        transform.LookAt(_target.position + _distanceFromTarget);
    }
}
