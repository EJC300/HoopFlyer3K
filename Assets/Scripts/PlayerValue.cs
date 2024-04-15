using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerValue
{
    public string Name;
    public  float maxValue;
    public float value;
  
    public void ChangeValue(float amount,bool sign)
    {
        if(sign)
        {
            value += amount * 1;
        }
        else
        {
            value += amount * -1;
        }
        ClampValue();
    }

    void ClampValue()
    {
     
        value = Mathf.Clamp(value, 0, maxValue);
    }

}
