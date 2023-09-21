using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _level;

    [SerializeField] private GameObject Inventory;
    private Canvas _inventory;
    [SerializeField] private GameObject Status;
    private Canvas _status;
    [SerializeField] private GameObject Store;
    private Canvas _store;
    [SerializeField] private int BaseSortOrder;

    [SerializeField] private InputController _inputEvent;

    private Stack<eUIType> UIStack = new Stack<eUIType>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _inputEvent.OnExitEvent += CloseWindow;
        _inventory = Inventory.GetComponent<Canvas>();
        _status = Status.GetComponent<Canvas>();
        _store = Store.GetComponent<Canvas>();
    }

    public void CloseWindow(bool isPressed)
    {
        if (isPressed)
        {
            if (UIStack.Count > 0)
            {
                var window = UIStack.Pop();
                switch (window)
                {
                    case eUIType.Inventory:
                        CloseInventory();
                        break;
                    case eUIType.Status:
                        CloseStatus();
                        break;
                    case eUIType.Store:
                        CloseStore();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void ChangeName(string name)
    {
        _name.text = name;
    }

    private void ChangeLevel(int level)
    {
        _level.text = level.ToString();
    }

    public void OpenInventory()
    {
        if (Inventory.activeInHierarchy == false)
        {
            Inventory.SetActive(true);
            _inventory.sortingOrder = UIStack.Count + BaseSortOrder;
            UIStack.Push(eUIType.Inventory);
        }
    }
    public void CloseInventory()
    {
        if (Inventory.activeInHierarchy == true)
        {
            Inventory.SetActive(false);
            RemoveUIType(eUIType.Inventory);
        }
    }
    public void UpdateInventory()
    {

    }
    public void OpenStatus()
    {
        if (Status.activeInHierarchy == false)
        {
            Status.SetActive(true);
            _status.sortingOrder = UIStack.Count + BaseSortOrder;
            UIStack.Push(eUIType.Status);
        }
    }
    public void CloseStatus()
    {
        if (Status.activeInHierarchy == true)
        {
            Status.SetActive(false);
            RemoveUIType(eUIType.Status);
        }
    }
    public void UpdateStatus()
    {

    }
    public void OpenStore()
    {
        if (Store.activeInHierarchy == false)
        {
            Store.SetActive(true);
            _store.sortingOrder = UIStack.Count + BaseSortOrder;
            UIStack.Push(eUIType.Store);
        }
    }
    public void CloseStore()
    {
        if (Store.activeInHierarchy == true)
        {
            Store.SetActive(false);
            RemoveUIType(eUIType.Store);
        }
    }
    private void RemoveUIType(eUIType type)
    {
        int count = UIStack.Count;
        Stack<eUIType> temp = new Stack<eUIType>();
        for (int i = 0; i < count; ++i)
        {
            var window = UIStack.Pop();
            if (window == type)
                continue;
            temp.Push(window);
        }
        count = temp.Count;
        for (int i = 0; i < count; ++i)
        {
            var window = temp.Pop();
            UIStack.Push(window);
        }
    }
}

public enum eUIType
{
    Inventory,
    Status,
    Store,
}