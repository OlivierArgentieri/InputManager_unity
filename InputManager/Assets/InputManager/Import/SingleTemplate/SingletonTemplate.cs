using System;
using UnityEngine;

public class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = default(T);
    public static T Instance => instance;


    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance == null)
            instance = this as T;

        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        
        
    }
}