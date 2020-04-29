using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeGenerator : MonoBehaviour
{
    public float secondsToSpawn;
    private float seconds = 0;
    public int spawnsPerSecond;
    public float speed = 1.0f;

    public GameObject snowflake;
    public Settings settings;

    // Update is called once per frame
    void Update()
    {
        if (settings.particlesToggle.isOn)
        {
            seconds += Time.deltaTime;
            if (seconds >= secondsToSpawn)
            {
                seconds = 0;
                for (int i = 0; i < spawnsPerSecond; ++i)
                {
                    GameObject g = Instantiate(snowflake, transform);
                    g.GetComponent<SnowflakeScript>().Init(speed);
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; ++i)
                Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void ChangeValues(float percent)
    {
        if (percent < 0.5f)
        {
            secondsToSpawn = 1.0f;
            spawnsPerSecond = 1;
            speed = 1.0f;
        }
        else if (percent >= 0.5f && percent < 0.75f)
        {
            secondsToSpawn = 0.5f;
            spawnsPerSecond = 2;
            speed = 1.5f;
        }
        else if (percent >= 0.75f)
        {
            secondsToSpawn = 0.25f;
            spawnsPerSecond = 4;
            speed = 2.0f;
        }
    }
}
