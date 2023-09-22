using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class EquipmentSystem : EquipmentEvents
{
    private EquipItemSO[] _equipItemSOs = new EquipItemSO[5];
    public EquipItemSO Head { get => _equipItemSOs[(int)eEquipPart.Head]; }
    public EquipItemSO Body { get => _equipItemSOs[(int)eEquipPart.Body]; }
    public EquipItemSO Arm { get => _equipItemSOs[(int)eEquipPart.Arm]; }
    public EquipItemSO Leg { get => _equipItemSOs[(int)eEquipPart.Leg]; }
    public EquipItemSO Weapon { get => _equipItemSOs[(int)eEquipPart.Weapon]; }
    private CharacterStatsController _characterStatsController;

    public void Init(CharacterStatsController characterStatsController)
    {
        _characterStatsController = characterStatsController;
    }


    public void TryEquip(EquipItemSO item)
    {
        var type = item.GetEquipPart();
        if (_equipItemSOs[(int)type] == null)
        {
            _equipItemSOs[(int)type] = item;
            item.OnEquip(_characterStatsController);
            CallOnEquip();
        }
        else if (_equipItemSOs[(int)type] != null && !_equipItemSOs[(int)type].Equals(item))
        {
            _equipItemSOs[(int)type] = item;
            item.OnEquip(_characterStatsController);
            CallOnEquip();
        }
    }

    public void TryUnequip(eEquipPart type)
    {
        if (_equipItemSOs[(int)type] != null)
        {
            _equipItemSOs[(int)type].OnUnEquip(_characterStatsController);
            _equipItemSOs[(int)type] = null;
            CallOnUnequip();
        }
    }

    public void TryUnequip(EquipItemSO item)
    {
        if (CheckEquip(item))
        {
            TryUnequip(item.GetEquipPart());
        }
    }

    public bool CheckEquipExist(eEquipPart eEquipPart)
    {
        if (_equipItemSOs[(int)eEquipPart] == null)
            return false;
        else
            return true;
    }

    public bool CheckEquip(EquipItemSO item)
    {
        foreach (var type in _equipItemSOs)
        {
            if (item.Equals(type)) return true;
        }
        return false;
    }
}