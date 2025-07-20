using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] float turretRange = 20f;
    [SerializeField] float turretRotationSpeed = 5f;
    private bool IsPlayerNear;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        Vector3 playerGroundPos = new Vector3(playerTransform.position.x,
                                  transform.position.y, playerTransform.position.z);

        if (Vector3.Distance(transform.position, playerGroundPos) > turretRange)
        {
            IsPlayerNear = false;
            return;
        }
        else
        {
            IsPlayerNear = true;
        }

        Vector3 playerDirection = playerGroundPos - transform.position;
        float turretRotationStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
                                   turretRotationStep, 0f);
        transform.rotation = Quaternion.LookRotation(newLookDirection);
    }

    public bool GetPlayerNear() => IsPlayerNear;
}
