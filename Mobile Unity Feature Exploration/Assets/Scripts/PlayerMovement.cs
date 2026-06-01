using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveForce = 20f;
    [SerializeField] private float _maxSpeed = 12f;
    [SerializeField] private float _smoothing = 0.15f;
    [SerializeField] private bool _invertX;
    [SerializeField] private bool _invertY;

    private Rigidbody _rb;
    private Vector3 _smoothedAcel;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // Enables acceleromter
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    // Applies movement based on accelermeter on player
    private void ApplyMovement()
    {
        if (Accelerometer.current == null)
        {
            return;
        }

        // Get Acceleration
        Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
        _smoothedAcel = Vector3.Lerp(_smoothedAcel, acceleration, _smoothing);

        float x = _invertX ? _smoothedAcel.x : -_smoothedAcel.x;
        float z = _invertY ? _smoothedAcel.y : -_smoothedAcel.y;

        // Clamp Acceleration
        Vector3 newAccel = new Vector3(x, 0, z) * _moveForce;
        newAccel = Vector3.ClampMagnitude(newAccel, _maxSpeed);

        // Add Force
        _rb.AddForce(newAccel, ForceMode.Acceleration);
    }
}

