using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class InventorySystem : InventoryEvents
{
    private List<BaseItemData> Inven = new List<BaseItemData>();

    public void Initialize(BaseItemData[] items)
    {
        Inven.AddRange(items);
    }

    public BaseItemData GetItemAtIndex(int index)
    {
        return Inven[index];
    }

    public T GetItemAtIndex<T>(int index) where T : BaseItemData
    {
        return Inven[index] as T;
    }

    public BaseItemData[] GetItems() 
    {
        return Inven.ToArray();
    }

    public void SortItem(Comparison<BaseItemData> sort)
    {
        Inven.Sort(sort);
    }

    public void BuyItem<T>(T item) where T : BaseItemData
    {
        T addItem = UnityEngine.Object.Instantiate<T>(item);
        CallOnBuy(addItem);
    }

    public void SellItem<T>(T item) where T : BaseItemData
    {
        Inven.Remove(item);
        CallOnSell(item);
    }
}
