using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventorySystem Inventory { get; private set; }
    public EquipmentSystem Equipment { get; private set; }

    public event Action OnEquip;
    public event Action OnSell;
    public event Action OnBuy;
    public event Action OnRemove;
    public event Action OnAdd;

    public void CallOnEquip()
    {
        OnEquip?.Invoke();
    }

    public void CallOnSell()
    {
        OnSell?.Invoke();
    }

    public void CallOnBuy()
    {
        OnBuy?.Invoke();
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
