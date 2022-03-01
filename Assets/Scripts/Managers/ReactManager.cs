using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ReactManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Login();

    [DllImport("__Internal")]
    private static extern void ScoreUpdate(int _score);

    public delegate void OnEventTrigger<T>(T data);
    public OnEventTrigger<string> OnLoginSuccess;

    
    public void Init()
    {
        
    }

    public void OnLogin()
    {
        try
        {
            Login();
        }
        catch(Exception ex)
        {
            Debug.LogError("ReactManager || OnLogin Error ||" + ex.Message);
        }        
    }

    public void LoginSuccess(string message)
    {
        OnLoginSuccess?.Invoke(message);
    }

    public void React_ScoreUpdate(int score)
    {
        ScoreUpdate(score);
    }
}
