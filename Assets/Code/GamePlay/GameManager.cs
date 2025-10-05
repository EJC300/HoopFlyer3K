using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEventListener StartGameListener;
    private void Start()
    {
        StartGameListener.Respond();
    }


}
