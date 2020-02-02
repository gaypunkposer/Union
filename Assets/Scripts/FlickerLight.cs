using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public AnimationCurve flickerCurve;
    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public float offset;
    public float speed;
    
    private float _timer;

    private void Start()
    {
        _timer = offset;
    }

    private void Update()
    {
        _timer = (_timer > flickerCurve.keys[flickerCurve.length - 1].time) ? 0 : _timer + Time.deltaTime * speed;
        light.intensity = flickerCurve.Evaluate(_timer);
    }
}
