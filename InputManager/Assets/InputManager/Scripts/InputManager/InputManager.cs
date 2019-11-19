using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonTemplate<InputManager>
{
    [SerializeField] public List<MyKey> ActionKey;


    private void Update()
    {
        foreach (var myKey in ActionKey)
        {
            if(Input.GetKeyDown(myKey.Key))
                Debug.Log("test");
        }
    }
}