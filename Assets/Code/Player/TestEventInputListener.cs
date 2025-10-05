using System;
using UnityEngine;
using UnityEngine.Events;




public class TestEventInputListener : MonoBehaviour
{
    public PlayerControls gameplay = default;
   public bool fire;
    public Vector3 move;
    private void OnEnable()
    {
        gameplay.MouseEventFire += FireEventTest;
        gameplay.MouseEventFireCancled += CancelFire;
        gameplay.MouseEventMove += MoveMouse;
      
    }
    private void OnDisable()
    {
        gameplay.MouseEventFire -= FireEventTest;
        gameplay.MouseEventFireCancled -= CancelFire;
        gameplay.MouseEventMove -= MoveMouse;
    }
    public void FireEventTest()
    {
       fire = true;
    }
    public void CancelFire()
    {
        fire = false;
    }
    public void MoveMouse(Vector2 value)
    {
        move = value;
      
    }
    private void Update()
    {
        if (fire)
        {
            Debug.Log(fire);
        }
        Debug.Log(new Vector3(Camera.main.ScreenToWorldPoint(move).x, Camera.main.ScreenToWorldPoint(move).y, 10f));
    }


}
