using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider fuelBar;
    [SerializeField] private PlayerValue health;
    [SerializeField] private PlayerValue fuel;
    public void Damage(float damageAmount)
    {
        health.ChangeValue(damageAmount, false);
    }
    public void DrainFuel(float fuelAmount)
    {
      if(fuel.value > 0)
        {
            fuel.ChangeValue(fuelAmount, false);
        }
    }

    public void IncreaseFuel(float fuelAmount)
    {
        fuel.ChangeValue(fuelAmount,true);
    }
   private void Update()
    {
       float healthPercentage = health.value/health.maxValue;
       float fuelPercentage = fuel.value/fuel.maxValue;

       healthBar.value = healthPercentage;
       fuelBar.value = fuelPercentage;
    }

    //On health is zero destroy player and instantiate player husk then hit pause menu
}
