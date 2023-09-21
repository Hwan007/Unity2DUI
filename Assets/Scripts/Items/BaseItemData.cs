using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public abstract class BaseItemData : ScriptableObject
{
    [SerializeField] protected string Name;
    [SerializeField] protected string Description;
    [HideInInspector] protected int ID = -1;
    [SerializeField] protected Sprite icon;
    [SerializeField] protected int Price;

    public virtual string GetName()
    {
        return Name;
    }
    public virtual string GetDescription()
    {
        return Description;
    }
    public virtual int GetID()
    {
        if (ID == -1)
            ID = ItemDataManager.Instance.GetID(this);
        return ID;
    }
    public virtual Sprite GetImage()
    {
        return icon;
    }
    public virtual int GetPrice(eTradeType type)
    {
        switch (type)
        {
            case eTradeType.Sell:
                return Price * GameManager.Instance.SellPercentage / 100;
            case eTradeType.Buy:
                return Price;
        }
        return Price;
    }
}

public enum eTradeType
{
    Sell,
    Buy,
}

public interface IPickupable
{
    public void OnPickup(GameObject receiver);
}

public interface IConsumable
{
    public void OnConsume(GameObject receiver) { }
}

public interface ITradable
{
    public int GetPrice();
}

public interface IEquipable
{
    public eEquipPart GetEquipPart();
    public void OnEquip(CharacterStatsController character);
    public void OnUnEquip(CharacterStatsController character);
}

public enum eEquipPart
{
    Head,
    Body,
    Arm,
    Leg,
    Weapon
}