using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIfTouching : MonoBehaviour
{
    void Update()
    {
        transform.position = TouchInput.Instance.PositionObject.position;
    }
}
