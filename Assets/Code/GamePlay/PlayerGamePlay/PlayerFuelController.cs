using Events;
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
    }

    public void Refuel(float amount)
    {
        Fuel += amount;
        Debug.Log(Fuel + " " + amount);
    }

    private void FuelDrain()
    {
        if (Fuel > 0.0f)
        {
            Fuel -= 01.0f * Time.deltaTime;
        }


    }
}
