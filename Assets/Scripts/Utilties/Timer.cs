using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class Timer
{

    [SerializeField] private TimeObject timeObject;

    [SerializeField] private float tickSpeed;
    public bool TimerStopped()
    {
        float dt = Time.deltaTime;

        float seconds = timeObject.startSeconds;

        float minutes = timeObject.startMinutes *60;

        float hours = timeObject.startHours * 36000;

        if (seconds > 0 && minutes > 0 && hours > 0)
        {
            seconds -= dt * tickSpeed;
            hours -= dt * tickSpeed;
            minutes -= dt * tickSpeed;  
        }
        else
        {
            SwapValue(seconds, timeObject.startSeconds);
            SwapValue(minutes, timeObject.startMinutes);
            SwapValue(hours, timeObject.startHours);
            return true;
        }
        return false;
    }
    public void SwapValue(float value,float newValue)
    {
         float temp = value;
         value = newValue;
         newValue = temp;
        
     
    }
    [System.Serializable]
    private class TimeObject
    {
        public float startSeconds;

        public float startMinutes;

        public float startHours;
    }
}
