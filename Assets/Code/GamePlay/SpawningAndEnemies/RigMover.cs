using UnityEditor;
using UnityEngine;

public class RigMover : MonoBehaviour
{
    public float MoveSpeed;
    private float currentSpeed;
    public float BoostSpeed;

    private bool StartGame;

    public void Awake()
    {
        currentSpeed = MoveSpeed;
    }
    public void IncreaseSpeed()
    {
       currentSpeed= BoostSpeed;
    }
    public void DecreaseSpeed()
    {
        currentSpeed= MoveSpeed;
    }
    public void InitRigMover()
    {
        StartGame = true;
    }

    private void Update()
    {
        if (StartGame)
        {

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }



}
