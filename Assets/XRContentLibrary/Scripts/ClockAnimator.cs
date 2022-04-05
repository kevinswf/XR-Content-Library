using System;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    [SerializeField]
    private Transform hours;
    [SerializeField]
    private Transform minutes;
    [SerializeField]
    private Transform seconds;

    private const float hoursToDegrees = 360.0f / 12.0f;
    private const float minutesToDegrees = 360.0f / 60.0f;
    private const float secondsToDegrees = 360.0f / 60.0f;

    void Update()
    {
        DateTime time = DateTime.Now;
        TimeSpan timeSpan = DateTime.Now.TimeOfDay;

        // rotate the clock hands, hour and minute hand is analog
        hours.localRotation = Quaternion.Euler((float) timeSpan.TotalHours * hoursToDegrees, 0, 0);
        minutes.localRotation = Quaternion.Euler((float) timeSpan.TotalMinutes * minutesToDegrees, 0, 0);
        seconds.localRotation = Quaternion.Euler(time.Second * secondsToDegrees, 0, 0);
    }
}
