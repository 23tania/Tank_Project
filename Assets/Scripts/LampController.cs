using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    private Light light;
    private float maxIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        maxIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        // Our lamps shine only during the night
        float currentTimeOfDay = GameObject.Find("Sun").GetComponent<SunController>().currentTimeOfDay;

        // Checks current time
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            // Makes the intensity of the light max
            light.intensity = maxIntensity;
        }
        else
        {
            light.intensity = 0;
        }
    }
}
