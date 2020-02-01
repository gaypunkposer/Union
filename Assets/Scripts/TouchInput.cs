using System;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime;
using TMPro;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public static TouchInput Instance => _instance;
    public Vector2 TouchPosition => _touchPos;
    
    public bool shouldUseMouse = true;
    public float minDragDistance = 1f;

    private static TouchInput _instance;
    private Vector2 _touchPos;
    private Touchable _touchedObject;

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    private static bool IsTouching()
    {
        return Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0);
    }

    private bool TouchStarted()
    {
        return (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0);
    }

    private bool TouchEnded()
    {
#if UNITY_EDITOR
        if (shouldUseMouse)
            return Input.GetMouseButtonUp(0);
#endif
         return Input.touchCount == 0 || (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled));
    }
    
    private void Update()
    {
        if (!IsTouching()) return;
#if UNITY_EDITOR
        _touchPos = shouldUseMouse ? GetScreenToWorld(Input.mousePosition) : GetScreenToWorld(Input.GetTouch(0).position);
#else
        _touchPos = GetScreenToWorld(Input.GetTouch(0).position);
#endif
        if (TouchStarted())
        {
            RaycastHit2D hit = Physics2D.CircleCast(_touchPos, 1f, Vector2.zero, 1, 1 << 8, -10, 10);
            if (!hit)
            {
                _touchedObject = null;
                return;
            }
                
            _touchedObject = hit.rigidbody.gameObject.GetComponent<Touchable>();
            _touchedObject.InvokeIfActive(_touchedObject.onTouchStart);
            Debug.Log("Touched object: " + _touchedObject);
        }
        else if (TouchEnded() && _touchedObject != null)
        {
            _touchedObject.InvokeIfActive(_touchedObject.onTouchEnd);
            _touchedObject = null;
            Debug.Log("touch ended");
        }
        else if (_touchedObject)
        {
            Vector3 delta = _touchPos - _touchedObject.Position;;
            
            if (delta.magnitude > minDragDistance)
            {
                _touchedObject.InvokeIfActive(_touchedObject.onDragged);
            }
            else
            {
                _touchedObject.InvokeIfActive(_touchedObject.onHeld);
            }
        }
    }
    
    private static Vector2 GetScreenToWorld(Vector3 raw)
    {
        Vector3 converted = Camera.main.ScreenToWorldPoint(raw);
        converted.z = 0;
        return new Vector2(converted.x, converted.y);
    }
}