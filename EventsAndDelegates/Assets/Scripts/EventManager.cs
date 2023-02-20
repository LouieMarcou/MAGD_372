using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ThrowUpAction();
    public static event ThrowUpAction OnThrowUp;

    public delegate void ThrowLeftAction();
    public static event ThrowLeftAction OnThrowLeft;

    public delegate void ThrowRightAction();
    public static event ThrowLeftAction OnThrowRight;

    private void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Up"))
        {
            OnThrowUp?.Invoke();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, 5, 100, 30), "Left"))
        {
            OnThrowLeft?.Invoke();
        }
        if (GUI.Button(new Rect(Screen.width / 2 + 50, 5, 100, 30), "Right"))
        {
            OnThrowRight?.Invoke();
        }
    }
}
