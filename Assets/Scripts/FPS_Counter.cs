using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour
{
    public float updateInterval = 0.5F;
    public string tOut;
    [SerializeField] public Text text;

    private float accum = 0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft = 0f; // Left time for current interval

    private void Start()
    {
        timeleft = updateInterval;
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            tOut = string.Format("{0:F0} FPS", fps);
            timeleft = updateInterval;
            accum = 0f;
            frames = 0;
        }
        if (text != null)
        {
            text.text = tOut;
        }
    }
}
