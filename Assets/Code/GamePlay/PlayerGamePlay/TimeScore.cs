using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TimeScore : MonoBehaviour
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

   public string TimeScoreString(string playerName)
    {
        return  $"Player Name {playerName} : Seconds {seconds} : Minutes {minutes} : Hours {hours} ";
    }


}
