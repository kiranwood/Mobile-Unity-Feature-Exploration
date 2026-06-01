using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _moveSpeed;

    private Vector3 _startPos;
    private Vector3 _travelPos;

    private int _direction = 1;
    private float _startTime;

    private void OnEnable()
    {
        SetTravelDestination();
    }

    private void FixedUpdate()
    {
        // Moves platform using time
        float distCovered = (Time.time - _startTime) * _moveSpeed;
        float fractionOfTravel = distCovered / _distance;

        transform.position = Vector3.Lerp(_startPos, _travelPos, fractionOfTravel);

        // Hit travel position
        if (fractionOfTravel >= 1)
        {
            SetTravelDestination();
        }
    }

    // Switches positions for the 
    private void SetTravelDestination()
    {
        _startPos = transform.position;
        _travelPos = _startPos;
        _travelPos.x += _direction * _distance;

        _direction *= -1;
        _startTime = Time.time;
    }
}
