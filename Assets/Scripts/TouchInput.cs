using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public static TouchInput Instance => _instance;
    public Transform PositionObject => _touchObject;
    public bool shouldUseMouse;
    
    private static TouchInput _instance;
    private Transform _touchObject;

    private void Start()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        }

        GameObject pos = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity) as GameObject;
        pos.name = "Touch Position";
        _touchObject = pos.transform;

        _instance = this;
    }

    public bool IsTouching()
    {
        return Input.touchCount > 0 || Input.GetMouseButton(0);
    }

    void Update()
    {
        if (IsTouching())
        {
#if UNITY_EDITOR
            if (shouldUseMouse)
                _touchObject.position = GetMousePosition();
            else
                _touchObject.position = GetTouchPosition();
#else
            _touchObject.position = GetTouchPosition();
#endif
        }
        else
        {
            _touchObject.position = Vector3.zero;
        }
    }

    private Vector3 GetTouchPosition()
    {
        if (Input.touchCount == 0) return Vector3.zero;
        
        Vector2 rawPos = Input.GetTouch(0).position;
        Vector3 converted = Camera.main.ScreenToWorldPoint(rawPos);
        converted.z = 0;
        return converted;
    }

    private Vector3 GetMousePosition()
    {
        if (!Input.GetMouseButton(0)) return Vector3.zero;
        
        Vector3 rawPos = Input.mousePosition;
        rawPos.z = 0;
        Vector3 converted = Camera.main.ScreenToWorldPoint(rawPos);
        converted.z = 0;
        return converted;
    }
}