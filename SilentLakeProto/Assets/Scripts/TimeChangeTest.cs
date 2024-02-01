using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeTest : MonoBehaviour
{
    public Material sky;

    private void Update()
    {
        RenderSettings.skybox = sky;
    }
}
