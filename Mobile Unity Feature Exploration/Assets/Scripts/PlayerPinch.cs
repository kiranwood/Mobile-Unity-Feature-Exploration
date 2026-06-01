using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerPinch : MonoBehaviour
{
    [SerializeField] private float minScale = 0.25f;
    [SerializeField] private float maxScale = 3;

    private float _pinchScaleModifier = 0.002f;
    private float _prevPinchDistance;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        // Pinching screen
        if (Touch.activeTouches.Count == 2)
        {
            HandlePinch(Touch.activeTouches[0], Touch.activeTouches[1]);
        }
    }
    
    // Increases scale of object 
    private void HandlePinch(Touch t1, Touch t2)
    {
        float currentPinchDistance = Vector2.Distance(t1.screenPosition, t2.screenPosition);

        // First touch
        if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
        {
            _prevPinchDistance = currentPinchDistance;
        }

        // Calculate new scale
        float difference = currentPinchDistance - _prevPinchDistance;
        float scaled = difference * _pinchScaleModifier;

        float newScale = Mathf.Clamp(transform.localScale.x + scaled, minScale, maxScale);

        // Changes new scale
        transform.localScale = Vector3.one * newScale;

        _prevPinchDistance = currentPinchDistance;
    }
}
