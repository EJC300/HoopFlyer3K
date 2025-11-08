using Events;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuelController : MonoBehaviour
{
    public float Fuel = 100;
    public FloatEventListener FuelListener;
    public VoidEventListener DeactivatePlayerListener;
    public Slider FuelSlider;
    private void Update()
    {
        FuelDrain();
        FuelSlider.value = Fuel;
        if (Fuel < 0)
        {
            Fuel = 0;
            DeactivatePlayerListener.Respond();

        }
        Fuel = Mathf.Clamp(Fuel,0,100);
    }

    public void Refuel(float amount)
    {
        
        if(Fuel  < 100)
        {
            Fuel += amount;
        }
  
        Debug.Log(Fuel + " " + amount);
    }

    private void FuelDrain()
    {
        if (Fuel > 0.0f)
        {
            Fuel -= 3.0f * Time.deltaTime;
        }


    }

    public IEnumerator DrainFuelOnBoost()
    {
        float duration = 0;
        while(duration < 0.5f)
        {
            Fuel -= 15 * Time.deltaTime;
            duration += Time.deltaTime;
            yield return null;
           

         }
    }
    public void FuelDrainByBoost()
    {
       StartCoroutine(DrainFuelOnBoost());
    }
    public void StopFuelDrainByBoost()
    {
        StopCoroutine(DrainFuelOnBoost());
    }
}
