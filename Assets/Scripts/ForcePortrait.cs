using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePortrait : MonoBehaviour
{
    void Start()
    {
        SetPortrait();
    }

    public void SetPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
