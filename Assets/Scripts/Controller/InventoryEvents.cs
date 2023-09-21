using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEvents
{
    public event Action<BaseItemData> OnSell;
    public event Action<BaseItemData> OnBuy;
    public event Action OnRemove;
    public event Action OnAdd;

    public void CallOnSell(BaseItemData item)
    {
        OnSell?.Invoke(item);
    }

    public void CallOnBuy(BaseItemData item)
    {
        OnBuy?.Invoke(item);
    }

    public void CallOnRemove()
    {
        OnRemove?.Invoke();
    }

    public void CallOnAdd()
    {
        OnAdd?.Invoke();
    }
}
