using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EquipmentEvents
{
    public event Action OnEquip;
    public event Action OnUnequip;

    public void CallOnEquip()
    {
        OnEquip?.Invoke();
    }

    public void CallOnUnequip()
    {
        OnUnequip?.Invoke();
    }
}
