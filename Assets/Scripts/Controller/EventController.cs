using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<bool> OnEnterEvent;
    public event Action<bool> OnExitEvent;
    public event Action<Vector2> OnClickEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallEnterEvent(bool isPressed)
    {
        OnEnterEvent?.Invoke(isPressed);
    }
    public void CallExitEvent(bool isPressed)
    {
        OnExitEvent?.Invoke(isPressed);
    }
    public void CallClickEvent(Vector2 position)
    {
        OnClickEvent?.Invoke(position);
    }
}
