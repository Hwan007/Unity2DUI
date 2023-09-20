using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultHealItem", menuName = "Scriptable Object/Item/HealItem", order = 3)]
public class HealConsumeItemSO : BaseItemData, IConsumable
{
    [SerializeField] private int heal;
    public override int GetID()
    {
        if (ID == -1)
            ID = ItemDataManager.Instance.GetID(this);
        return ID;
    }

    void IConsumable.OnConsume(GameObject receiver)
    {
        var healthSystem = receiver.GetComponent<HealthSystem>();
        if (healthSystem != null )
        {
            healthSystem.ChangeHealth(heal);
        }
    }
}
