using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private Animator _animator;
    private Camera _camera;
    private Rigidbody _rb;
    private CoinController _coinController;
    private LifeController _lifeController;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        _coinController = GetComponent<CoinController>();
        _lifeController = GetComponent<LifeController>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = horizontal * _camera.transform.right + vertical * _camera.transform.forward;
        direction.y = 0f;
        direction = direction.normalized;

        Vector3 cameraEuler = _camera.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, cameraEuler.y, 0f);

        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));
    }

    public void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Coin"))
        {
            _coinController.AddCoin();
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            Bullet bullet = collision.collider.gameObject.GetComponent<Bullet>();
            _lifeController.AddHp(-bullet.GetDamage());
        }

        if (collision.collider.CompareTag("Lava"))
        {
            _lifeController.AddHp(-_lifeController.CurrentHp);
        }
    }
}
