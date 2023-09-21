using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


public class EquipmentSystem : EquipmentEvents
{
    private List<EquipItemSO> _equipItemSOs = new List<EquipItemSO>();
    public EquipItemSO Head { get => _equipItemSOs[(int)eEquipPart.Head]; }
    public EquipItemSO Body { get => _equipItemSOs[(int)eEquipPart.Body]; }
    public EquipItemSO Arm { get => _equipItemSOs[(int)eEquipPart.Arm]; }
    public EquipItemSO Leg { get => _equipItemSOs[(int)eEquipPart.Leg]; }
    public EquipItemSO Weapon { get => _equipItemSOs[(int)eEquipPart.Weapon]; }

    public void TryEquip(EquipItemSO item)
    {
        var type = item.GetEquipPart();
        if (_equipItemSOs[(int)type] != null && !_equipItemSOs[(int)type].Equals(item))
        {
            _equipItemSOs[(int)type] = item;
            CallOnEquip(item);
        }
    }

    public void TryUnequip(eEquipPart type)
    {
        if (_equipItemSOs[(int)type] != null)
        {
            _equipItemSOs[(int)type] = null;
            CallOnUnequip(type);
        }
    }

    public bool CheckEquipExist(eEquipPart eEquipPart)
    {
        if (_equipItemSOs[(int)eEquipPart] == null)
            return false;
        else
            return true;
    }
}