using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLandscape : MonoBehaviour
{
    
    void Start()
    {
        SetLandscape();
    }

    public void SetLandscape()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
