using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance { get; set; }
    public static T Instance
    {
        get
        {

            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();
                SetupInstance();
            }
            return instance;
        }
    }
   
    public void Initialize()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
    
            instance = GameObject.FindObjectOfType<T>();

            if(instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = typeof(T).Name;  
                instance = gameObj.AddComponent<T>();
                DontDestroyOnLoad(gameObj);
                
                
            }
        
    }

    private void RemoveDuplicates()
    {
        if(instance == null) 
        {

            instance = this as T;

            GameObject.DontDestroyOnLoad(gameObject);


        
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }


}
