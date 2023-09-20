using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    [HideInInspector] public static ItemDataManager Instance;
    public List<BaseItemData> Datas = new List<BaseItemData>();

    private Stack<int> IDStack = new Stack<int>();
    [SerializeField] private int IDStackSize;
    [SerializeField][Range(1,100)] private int ResizeStackSize;

    private Dictionary<int, BaseItemData> IDItem = new Dictionary<int, BaseItemData>();

    private void Awake()
    {
        Instance = this;
        MakeIDStack();
    }

    public BaseItemData GetItem(int id)
    {
        return IDItem[id];
    }
    public int GetID(BaseItemData item)
    {
        if (IDStack.Count == 0)
            UpsizeIDStack(ResizeStackSize);
        int ret = IDStack.Pop();
        IDItem.Add(ret, item);
        return ret;
    }
    public void ReturnID(int ID)
    {
        IDItem.Remove(ID);
        IDStack.Push(ID);
    }
    private void MakeIDStack()
    {
        for (int i = 0; i < IDStackSize; i++)
        {
            IDStack.Push(i);
        }
    }
    private void UpsizeIDStack(int size)
    {
        for (int i = IDStackSize; i < IDStackSize + size; i++)
        {
            IDStack.Push(i);
        }
    }
}
