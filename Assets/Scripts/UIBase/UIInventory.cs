using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIBase
{
    private InventoryController _inventoryController;
    private Action _callBack;
    public void Initialize(InventoryController inventoryController, Action callback = null)
    {
        _inventoryController = inventoryController;
        _callBack = callback;
    }
    public override void CloseUI()
    {
        _callBack?.Invoke();
        base.CloseUI();
    }
}
