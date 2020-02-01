using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour
{
    private void Update()
    {
        transform.position = TouchInput.Instance.TouchPosition;
    }
}
