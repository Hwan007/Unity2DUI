using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputController : EventController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (value.isPressed)
            CallMoveEvent(input);
        Debug.Log($"OnMove {input}:{value.isPressed}");
    }
    public void OnEnter(InputValue value)
    {

        CallEnterEvent(value.isPressed);
        Debug.Log($"OnEnter {value.isPressed}");
    }
    public void OnExit(InputValue value)
    {
        CallExitEvent(value.isPressed);
        Debug.Log($"OnExit {value.isPressed}");
    }
    public void OnClick(InputValue value)
    {
        Vector2 position = value.Get<Vector2>();
        CallClickEvent(position);
        Debug.Log($"OnClick {position}");
    }
}
