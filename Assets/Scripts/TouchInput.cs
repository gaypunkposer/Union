using System;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime;
using TMPro;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool shouldUseMouse = true;
    public float dragSpeed = .5f;
    public float minDragDistance = 1f;
    
    private static TouchInput _instance;
    private Touchable _draggedObject;
    public static bool IsTouching()
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
        if (TouchStarted())
        {
#if UNITY_EDITOR
            Vector2 touchPos = shouldUseMouse ? GetScreenToWorld(Input.mousePosition) : GetScreenToWorld(Input.GetTouch(0).position);
#else
            Vector2 touchPos = GetScreenToWorld(Input.GetTouch(0).position);
#endif
            RaycastHit2D hit = Physics2D.CircleCast(touchPos, 1f, Vector2.zero, 1, 1 << 8, -10, 10);
            if (!hit)
            {
                _draggedObject = null;
                return;
            }
                
            _draggedObject = hit.rigidbody.gameObject.GetComponent<Touchable>();
            _draggedObject.onTouchStart.Invoke();
            Debug.Log("Touched object: " + _draggedObject);
        }
        else if (TouchEnded() && _draggedObject != null)
        {
            _draggedObject.onTouchEnd.Invoke();
            _draggedObject = null;
            Debug.Log("touch ended");
        }
        else if (_draggedObject)
        {
            Vector3 delta;
#if UNITY_EDITOR
            if (shouldUseMouse)
            {
                delta = GetScreenToWorld(Input.mousePosition) - _draggedObject.Position;
            }
            else
            {
                delta = GetScreenToWorld(Input.GetTouch(0).position) - _draggedObject.Position;
            }
#else
                delta = GetScreenToWorld(Input.GetTouch(0).position) - _draggedObject.Position;
#endif
            _draggedObject.MoveToTouchDelta(delta * (dragSpeed * delta.magnitude * 0.75f));

            if (delta.magnitude > minDragDistance)
            {
                _draggedObject.onDragged.Invoke();
            }
            else
            {
                _draggedObject.onHeld.Invoke();
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