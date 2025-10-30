using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TimeScore 
{

    public float seconds;

    public float minutes;

    public float hours;//-ya right

    
    public void IncrementTime()
    {
        if(seconds < 60)
        {
            seconds += Time.deltaTime;
            
        }
        if(seconds > 60 &&minutes < 60)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes > 60 && hours < 60)
        {
            minutes = 0;
            hours++;
        }
    }

   public string TimeScoreString()
    {
        return  $" Seconds {seconds} : Minutes {minutes} : Hours {hours} ";
    }


}
