using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public enum Direction
{
    FadeIn, FadeOut
}
public class FadeImage : MonoBehaviour
{


    private float fadeSpeed = 0.5f;
    private Image fadeImage { get; set; }
    private float target {  get; set; }
    public Direction FadeDirection { get => fadeDirection; set => fadeDirection = value; }

    private Color fadeColor;

    private Direction fadeDirection;

    public void Awake()
    {
        
        if (fadeImage == null) { fadeImage = GetComponent<Image>(); }
       
        StartFade(Direction.FadeIn);
    }
  
    public void StartFade(Direction fadeDirection)
    {
        StartCoroutine(LoadScene(0,fadeDirection));
    }
    public IEnumerator LoadScene(int index, Direction fadeDirection)
    {
        
        yield return FadeColor(fadeDirection);
        LevelHandler.Instance.LoadLevel(index);
    }
    private IEnumerator FadeColor(Direction fadeDirection)
    {
        fadeColor = fadeImage.color;
        if (fadeDirection == Direction.FadeOut)
        {
            target = (float)Direction.FadeOut;
            while (target >= ChangeAlpha(fadeDirection))
            {
                fadeColor.a = QuasarMath.SmoothDamp(fadeColor.a, target,Time.deltaTime,fadeSpeed);
                fadeImage.color = fadeColor;
                yield return null;
            }
        }
        else if(fadeDirection == Direction.FadeIn)
        {
            target = (float)Direction.FadeIn;
            while (target <= ChangeAlpha(fadeDirection))
            {
                fadeColor.a = QuasarMath.SmoothDamp(fadeColor.a, target, Time.deltaTime, fadeSpeed);
                fadeImage.color = fadeColor;
               
                yield return null;
            }
        }
    }
    
    private float ChangeAlpha(Direction fadeDirection)
    {
     
        return this.FadeDirection == fadeDirection ? 1 : 0;
    }    

    
}
