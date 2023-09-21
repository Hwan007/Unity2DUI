using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEvents
{
    public event Action<EquipItemSO> OnEquip;
    public event Action<eEquipPart> OnUnequip;

    public void CallOnEquip(EquipItemSO item)
    {
        OnEquip?.Invoke(item);
    }

    public void CallOnUnequip(eEquipPart equipPart)
    {
        OnUnequip?.Invoke(equipPart);
    }
}
