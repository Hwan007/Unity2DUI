using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOX : UIBase
{
    private Action<bool> _ox;
    public void Initialize(Action<bool> callback)
    {
        _ox = callback;
    }

    public void ClickX()
    {
        _ox?.Invoke(false);
        CloseUI();
    }

    public void ClickO()
    {
        _ox?.Invoke(true);
        CloseUI();
    }

    public override void CloseUI()
    {
        //base.CloseUI();
        UIManager.Instance.RemoveUIInList(this);
        gameObject.SetActive(false);
    }
}
