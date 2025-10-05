using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    public LoadLevelSO LevelToLoad;

    public UnityEvent loadEvent;

   public void Loadlevel(Scene value)
    {
        LevelToLoad.RaiseEvent(value);
    }

    private void OnEnable()
    {
        LevelToLoad.OnLoadedScene += Loadlevel;
    }
    private void OnDisable()
    {
        LevelToLoad.OnLoadedScene -= Loadlevel;
    }

}
