using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private List<BaseItemData> Inven = new List<BaseItemData>();

    public T GetItemAtIndex<T>(int index)
    {
        if (Inven[index] is T)
        {
            T ret = (T)(object)Inven[index];
            return ret;
        }
        else
            return default(T);
    }

    public BaseItemData GetItemAtIndex(int index)
    {
        return Inven[index];
    }
}
