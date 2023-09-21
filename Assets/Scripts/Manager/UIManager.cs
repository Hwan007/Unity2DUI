using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public static UIManager Instance;
    
    [SerializeField] private InputController _inputEvent;

    [SerializeField] private int BaseSortOrder;
    [SerializeField] private List<UIBase> UIPrefabs = new List<UIBase>();

    private List<UIBase> UIOpened = new List<UIBase>();
    
    private UIObjectPool UIObjectPool;

    private void Awake()
    {
        Instance = this;
        UIObjectPool = GetComponent<UIObjectPool>();
    }

    private void Start()
    {
        _inputEvent.OnExitEvent += CloseTopUI;
    }

    public void CloseTopUI(bool isPressed)
    {
        if (isPressed)
        {
            if (UIOpened.Count > 0)
            {
                UIOpened[0].CloseUI();
            }
        }
    }

    private UIBase ShowUI(eUIType type)
    {
        var obj = UIObjectPool.SpawnFromPool(type);
        if (obj != null)
        {
            var uiBase = obj.GetComponent<UIBase>();
            UIOpened.Insert(0, uiBase);

            obj.SetActive(true);
            return uiBase;
        }
        else
            return null;
    }
    public T ShowUI<T>(eUIType type) where T : UIBase
    {
        return ShowUI(type) as T;
    }

    public bool IsOpened<T>() where T : UIBase
    {
        foreach (var ui in UIOpened)
        {
            if (ui is T)
                return true;
        }
        return false;
    }

    public void AllCloseUI()
    {
        foreach (var ui in UIOpened)
        {
            ui.CloseUI();
        }
    }

    public T GetUI<T>() where T : UIBase
    {
        foreach (var ui in UIOpened)
        {
            if (ui is T)
                return ui as T;
        }
        return null;
    }

    public void RemoveUIInList(UIBase uiBase)
    {
        UIOpened.Remove(uiBase);
    }
}