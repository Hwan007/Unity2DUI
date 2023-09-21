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

    private List<UIBase> UIOpened = new List<UIBase>();

    private CharacterStatsController _characterController;
    private HealthSystem _healthSystem;
    private PlayerInfoController _playerInfoController;
    private InventoryController _InventoryController;

    private UIObjectPool UIObjectPool;

    private void Awake()
    {
        Instance = this;
        UIObjectPool = GetComponent<UIObjectPool>();
    }

    private void Start()
    {
        _inputEvent.OnExitEvent += CloseTopUI;
        _characterController = GameManager.Instance.Player.GetComponent<CharacterStatsController>();
        _healthSystem = GameManager.Instance.Player.GetComponent<HealthSystem>();
        _playerInfoController = GameManager.Instance.Player.GetComponent<PlayerInfoController>();
        _InventoryController = GameManager.Instance.Player.GetComponent<InventoryController>();

        OpenNameLevel();
        OpenGold();

        _playerInfoController.OnNameChange += UpdateNameLevel;
        _playerInfoController.OnGoldChange += UpdateGold;
        _playerInfoController.OnLevelChange += UpdateNameLevel;
        _playerInfoController.OnStatChange += UpdateStats;
        _playerInfoController.RefreshInfo();
    }

    public void CloseUI<T>() where T : UIBase
    {
        var window = GetUI<T>();
        if (window != null)
        {
            window.CloseUI();
        }
    }

    public void CloseTopUI(bool isPressed)
    {
        if (isPressed)
        {
            if (UIOpened.Count > 0)
            {
                if (UIOpened[0] is UIGold || UIOpened[0] is UINameLevel || UIOpened[0])
                    return;
                UIOpened[0].CloseUI();
            }
        }
    }

    public T ShowUI<T>(eUIType type) where T : UIBase
    {
        var obj = UIObjectPool.SpawnFromPool(type);
        if (obj != null)
        {
            if (type == eUIType.Store || type == eUIType.Inventory || type == eUIType.Gold)
            {
                var uiClass = obj.GetComponentInChildren<UIBase>();
                UIOpened.Insert(0, uiClass);

                obj.SetActive(true);
                return uiClass as T;
            }
            else if (type == eUIType.InventoryItem || type == eUIType.OX)
            {
                var uiClass = obj.GetComponent<UIBase>();

                obj.SetActive(true);
                return uiClass as T;
            }
            else
            {
                var uiClass = obj.transform.GetChild(0).gameObject.AddComponent<T>();
                UIOpened.Insert(0, uiClass);

                obj.SetActive(true);
                return uiClass;
            }
        }
        else
            return null;
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
        if (GetUI<UIStatus>() == null)
        {
            var window = UIManager.Instance.ShowUI<UIStatus>(eUIType.Text);
            window.Initialize(_healthSystem, _characterController, () => { RemoveUIInList(window); });
        }
    }

    public void OpenNameLevel()
    {
        if (GetUI<UINameLevel>() == null)
        {
            var window = UIManager.Instance.ShowUI<UINameLevel>(eUIType.Text);
            window.Initialize(_playerInfoController);
        }
    }

    private void OpenGold()
    {
        if (GetUI<UIGold>() == null)
        {
            var window = UIManager.Instance.ShowUI<UIGold>(eUIType.Gold);
            window.Initialize(_playerInfoController);
        }
    }

    public void OpenInventory()
    {
        if (GetUI<UIInventory>() == null)
        {
            var window = UIManager.Instance.ShowUI<UIInventory>(eUIType.Inventory);
            window.Initialize(_InventoryController, () => { RemoveUIInList(window); });
        }
    }

    public void OpenStore()
    {

    }

    public void UpdateNameLevel()
    {
        if (GetUI<UINameLevel>() != null)
        {
            var window = GetUI<UINameLevel>();
            window.Refresh();
        }
    }

    public void UpdateGold()
    {
        if (GetUI<UIGold>() != null)
        {
            var window = GetUI<UIGold>();
            window.Refresh();
        }
    }

    private void UpdateStats()
    {
        if (GetUI<UIStatus>() != null)
        {
            var window = GetUI<UIStatus>();
            window.Refresh();
        }
    }
}