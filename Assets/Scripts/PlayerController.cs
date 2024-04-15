using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour,IDamagable
{
    [SerializeField] private float boostSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float rollAmount;
    [SerializeField] private float fuelDrainAmount;
    [SerializeField] private Mover rig;
    [SerializeField] private GameObject boostField;
    [SerializeField] private PlayerHealth health;
 
    private RandomRotator tumbler;
    private Transform childRoller;
    private Vector3 roll;
    private float lastSpeed;
    private float currentDrainAmount;
    private bool collide;
 

 
    public bool Collide { get => collide; set => collide = value; }
    public PlayerHealth Health { get => health; set => health = value; }

    private void Start()
    {
        lastSpeed = speed;
        childRoller = transform.GetChild(0);
        tumbler =  childRoller.GetComponent<RandomRotator>();
    }

    public void Tumble()
    {
       
       
       collide = true;
     
       
    }
    public void MoveShip(Vector3 mousePosition, float viewDistance)
    {
        if (!collide)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                boostField.SetActive(true);
                speed = boostSpeed;
                currentDrainAmount = 0.05f;
            }
            else
            {
                boostField.SetActive(false);
                speed = lastSpeed;
                currentDrainAmount = fuelDrainAmount;
            }
            rig.Speed = speed;
            tumbler.enabled = false;
            mousePosition = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewDistance)));
            float rollSpeed = speed * 2f;
            Vector3 destination = QuasarMath.SmoothDamp(transform.localPosition, mousePosition, Time.deltaTime, speed);
            Vector3 direction = destination - transform.localPosition;
            float axis = direction.x;



            if (axis < -0.05)
            {
                roll.z = QuasarMath.SmoothDamp(roll.z, rollAmount, Time.deltaTime, rollSpeed);
            }
            else if (axis > 0.05)
            {
                roll.z = QuasarMath.SmoothDamp(roll.z, -rollAmount, Time.deltaTime, rollSpeed);
            }
            else
            {
                roll.z = QuasarMath.SmoothDamp(roll.z, 0, Time.deltaTime, rollSpeed);
            }

            transform.localPosition = destination;

            childRoller.localRotation = Quaternion.Euler(roll);


        }
        else if (collide)
        {
            
            tumbler.enabled = true;


        }
        Health.DrainFuel(currentDrainAmount);
        tumbler.enabled = false;
        collide = false;

    }

    public void Damage(float damageAmount)
    {
        collide = true;
        Health.Damage(damageAmount);
    }
}
