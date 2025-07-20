using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;

    void Update()
    {
        transform.Rotate(0, _rotationSpeed, 0);
    }
}
