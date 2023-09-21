using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIBase
{
    private InventoryController _inventoryController;
    private Action _callBack;
    private UIObjectPool _ItemUIPool;
    private List<UIItemInfo> uIItems = new List<UIItemInfo>();

    public void Initialize(InventoryController inventoryController, Action callback = null)
    {
        _inventoryController = inventoryController;
        _callBack = callback;
        _ItemUIPool = GetComponent<UIObjectPool>();
    }
    public override void CloseUI()
    {
        _callBack?.Invoke();
        base.CloseUI();
    }
}
