using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public Light sun;
    public float seconds_in_day = 60.0f;

    [Range(0, 1)]
    public float current_time = 0.0f;

    [HideInInspector]
    public float time_multiplier = 1.0f;

    float sun_init_intensity;

    // Start is called before the first frame update
    void Start()
    {
        sun_init_intensity = sun.intensity;    
    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.localRotation = Quaternion.Euler((current_time * 360.0f), 270, 0);

        current_time += (Time.deltaTime / seconds_in_day) * time_multiplier;

        if(current_time >= 1)
        {
            current_time = 0;
        }
    }
}
