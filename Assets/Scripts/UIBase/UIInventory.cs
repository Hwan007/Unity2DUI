using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UIInventory : UIBase
{
    private InventoryController _inventoryController;
    private Action _callBack;
    private UIObjectPool _ItemUIPool;
    private List<UIItemInfo> _uiItems = new List<UIItemInfo>();

    public void Initialize(InventoryController inventoryController, Action callback = null)
    {
        _inventoryController = inventoryController;
        _callBack = callback;
        _ItemUIPool = GetComponent<UIObjectPool>();
        InitUI();
    }
    public override void CloseUI()
    {
        _callBack?.Invoke();
        ClaerUI();
        base.CloseUI();
    }
    public override void Refresh()
    {
        base.Refresh();
        ClaerUI();
        InitUI();
    }

    private void InitUI()
    {
        var items = _inventoryController.Inventory.GetItems();
        foreach (var item in items)
        {
            var obj = _ItemUIPool.SpawnFromPool(eUIType.InventoryItem);
            var info = obj.GetComponent<UIItemInfo>();

            if (item is EquipItemSO)
                info.InitInfo(item, _inventoryController.Equipment.CheckEquip(item as EquipItemSO), () => _uiItems.Remove(info), (x) => { if (x) _inventoryController.Equipment.TryEquip(item as EquipItemSO); });
            else
                info.InitInfo(item, false, () => _uiItems.Remove(info));

            _uiItems.Add(info);
            obj.SetActive(true);
        }
    }

    private void ClaerUI()
    {
        foreach (var item in _uiItems)
        {
            item.gameObject.SetActive(false);
        }
        _uiItems.Clear();
    }
}
