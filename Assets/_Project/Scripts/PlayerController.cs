using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    private Rigidbody _rb;
    private Camera _camera;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = horizontal * _camera.transform.right + vertical * _camera.transform.forward;
        direction.y = 0f;
        direction = direction.normalized;

        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));
    }

    public void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
}
