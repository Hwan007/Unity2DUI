using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<bool> OnEnterEvent;
    public event Action<bool> OnExitEvent;
    public event Action<bool> OnClickEvent;
    public event Action<Vector2> OnClickToPositionEvent;

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
    public void CallClickEvent(bool isPressed)
    {
        OnClickEvent?.Invoke(isPressed);
    }
    public void CallClickToPosition(Vector2 position)
    {
        OnClickToPositionEvent?.Invoke(position);
    }
}
