using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryController : MonoBehaviour
{
    public InventorySystem Inventory { get; private set; } = new InventorySystem();
    public EquipmentSystem Equipment { get; private set; } = new EquipmentSystem();

    private PlayerInfoController _playerInfoController;
    private CharacterStatsController _characterStatsController;

    [SerializeField] private bool TEST;
    [SerializeField] private List<BaseItemData> testItem;

    private void Awake()
    {
        if (TEST && testItem.Count > 0)
            Inventory.Initialize(testItem.ToArray());
    }
    private void Start()
    {
        _characterStatsController = GetComponent<CharacterStatsController>();
        Equipment.Init(_characterStatsController);
        _playerInfoController = GetComponent<PlayerInfoController>();
        Inventory.OnSell += SellItem;
        Inventory.OnBuy += BuyItem;
        Equipment.OnEquip += RecalStats;
        Equipment.OnUnequip += RecalStats;
    }

    private void RecalStats()
    {
        _playerInfoController.CallStatsChange();
    }

    public void Initialize(BaseItemData[] items, int[] equipIndex)
    {
        Inventory.Initialize(items);
        foreach (var index in equipIndex)
        {
            Equipment.TryEquip(Inventory.GetItemAtIndex<EquipItemSO>(index));
        }
    }
    private void BuyItem(BaseItemData item)
    {
        _playerInfoController.Info.ChangeGold(-item.GetPrice(eTradeType.Buy));
        _playerInfoController.CallGoldChange();
    }

    private void SellItem(BaseItemData item)
    {
        _playerInfoController.Info.ChangeGold(item.GetPrice(eTradeType.Sell));
        _playerInfoController.CallGoldChange();
    }

    
}
