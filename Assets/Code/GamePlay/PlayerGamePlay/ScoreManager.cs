using Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
public class ScoreManager : MonoBehaviour
{
   
    public TimeScore score;

    public Text player;

    public void Awake()
    {
        if (player.gameObject.activeInHierarchy)
        {
            player.gameObject.SetActive(false);
        }
    }

    public void DisplayTime()
    {
        player.transform.gameObject.SetActive(true);
        player.text = score.TimeScoreString() + "Play Again Press Left Mouse Button";
    }

    //Since this is a web game I don't need to exit the game.

    

}
