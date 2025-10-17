using UnityEngine;

public class RigMover : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    private bool StartGame;

    public void InitRigMover()
    {
        StartGame = true;
    }

    private void Update()
    {
        if (StartGame)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }



}
