using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public Light sun;
    public float secondsInFullDay = 120f;   // Time of day in seconds

    [Range(0, 1)]
    public float currentTimeOfDay = 0;

    [HideInInspector]
    public float timeMultiplier = 1f;   // To speed up you can make this number higher

    float sunInitialIntensity;
    Skybox skybox;

    // Start is called before the first frame update
    void Start()
    {
        sunInitialIntensity = sun.intensity;
        skybox = Camera.main.GetComponent<Skybox>();
    }

    

    void UpdateSun()
    {
        // Rotating the sun around the map
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        // Calculating the sun's position between different periods of time
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.23f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    private void UpdateExposure()
    {
        float exposure = 0f;

        if (currentTimeOfDay >= 0.5f)
        {
            exposure = 2 - (currentTimeOfDay * 2);
        }
        else
        {
            exposure = currentTimeOfDay * 2;
        }
        skybox.material.SetFloat("_Exposure", exposure);
    }

    private void OnApplicationQuit()
    {
        skybox.material.SetFloat("_Exposure", 1);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();
        UpdateExposure();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }
}
