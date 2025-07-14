using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _groundedCheckDistance = 0.1f;
    private bool _grounded;
    private PlayerController _controller;
    void Start()
    {
        _controller = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _controller.Jump();
        }
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _groundedCheckDistance, LayerMask.GetMask("Ground")))
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }
}
