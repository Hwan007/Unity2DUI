using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public static UIManager Instance;

    [SerializeField] private InputController _inputEvent;

    [SerializeField] private GameObject Status;
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject Store;
    [SerializeField] private TMP_Text Gold;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Level;

    private List<UIBase> UIOpened = new List<UIBase>();

    private CharacterStatsController _characterController;
    private HealthSystem _healthSystem;
    private PlayerController _playerController;
    private bool isOpenStatus = false;

    //private UIObjectPool UIObjectPool;

    private void Awake()
    {
        Instance = this;
        //UIObjectPool = GetComponent<UIObjectPool>();
    }

    private void Start()
    {
        _inputEvent.OnExitEvent += CloseTopUI;
        _characterController = GameManager.Instance.Player.GetComponent<CharacterStatsController>();
        _healthSystem = GameManager.Instance.Player.GetComponent<HealthSystem>();

        _playerController = GameManager.Instance.Player.GetComponent<PlayerController>();
        _playerController.OnNameChange += UpdateName;
        _playerController.OnGoldChange += UpdateGold;
        _playerController.OnLevelChange += UpdateLevel;
        _playerController.RefreshInfo();
    }

    public void CloseTopUI(bool isPressed)
    {
        if (isPressed)
        {
            if (UIOpened.Count > 0)
            {
                UIOpened[0].CloseUI();
            }
        }
    }

    private UIBase ShowUI(eUIType type)
    {
        //var obj = UIObjectPool.SpawnFromPool(type);
        GameObject obj = null;
        switch (type)
        {
            case eUIType.Status:
                obj = Status;
                break;
            case eUIType.Inventory:
                obj = Inventory;
                break;
            case eUIType.Store:
                obj = Store;
                break;
        }
        if (obj != null)
        {
            var uiBase = obj.GetComponent<UIBase>();
            UIOpened.Insert(0, uiBase);

            obj.SetActive(true);
            return uiBase;
        }
        else
            return null;
    }
    public T ShowUI<T>(eUIType type) where T : UIBase
    {
        return ShowUI(type) as T;
    }

    public bool IsOpened<T>() where T : UIBase
    {
        foreach (var ui in UIOpened)
        {
            if (ui is T)
                return true;
        }
        return false;
    }

    public void AllCloseUI()
    {
        foreach (var ui in UIOpened)
        {
            ui.CloseUI();
        }
    }

    public T GetUI<T>() where T : UIBase
    {
        foreach (var ui in UIOpened)
        {
            if (ui is T)
                return ui as T;
        }
        return null;
    }

    public void RemoveUIInList(UIBase uiBase)
    {
        UIOpened.Remove(uiBase);
    }

    public void OpenStatus()
    {
        if (!isOpenStatus)
        {
            var window = UIManager.Instance.ShowUI<UIStatus>(eUIType.Status);
            window.Initialize(_healthSystem, _characterController, () => { isOpenStatus = false; });
        }
    }

    public void OpenInventory()
    {

    }

    public void OpenStore()
    {

    }

    public void UpdateName(string name)
    {
        Name.text = name;
    }

    public void UpdateGold(int gold)
    {
        Gold.text = gold.ToString();
    }

    public void UpdateLevel(int level)
    {
        Level.text = level.ToString();
    }
}