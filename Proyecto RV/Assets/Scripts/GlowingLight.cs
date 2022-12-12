using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLight : MonoBehaviour
{
    private Light light;
    private float maxIntensity;
    private float minIntensity = 2f;
    void Start()
    {
        light = GetComponent<Light>();
        maxIntensity = light.intensity - minIntensity;
    }

    void Update()
    {
        //pingpong va de 0 al valor indicado como máx
        float nIntensity = Mathf.PingPong(Time.time * 3, maxIntensity);
        light.intensity = nIntensity + minIntensity;
    }
}
