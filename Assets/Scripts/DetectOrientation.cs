using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectOrientation : MonoBehaviour
{
    public UnityEvent onRotateLandscape;
    public UnityEvent onRotatePortrait;
    void Update()
    {
        
        switch (Input.deviceOrientation)
        {
            case DeviceOrientation.LandscapeLeft:
            case DeviceOrientation.LandscapeRight:
                onRotateLandscape.Invoke();
                break;
            case DeviceOrientation.Portrait:
            case DeviceOrientation.PortraitUpsideDown:
                onRotatePortrait.Invoke();
                break;
        }
    }
}
