using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStatModifyItem", menuName = "Scriptable Object/Item/StatModifyItem", order = 3)]
public class StatModifyConsumeItemSO : BaseItemData, IConsumable
{
    public static float TimeLimit = 100000f;
    [SerializeField] private CharacterStats modifier;
    /// <summary>
    /// 100000인 경우에는 영구 적용이다.
    /// </summary>
    [SerializeField][Range(0.1f, 100000f)] private float time;
    public override int GetID()
    {
        if (ID == -1)
            ID = ItemDataManager.Instance.GetID(this);
        return ID;
    }

    void IConsumable.OnConsume(GameObject receiver)
    {
        var statsController = receiver.GetComponentInChildren<CharacterStatsController>();
        if (statsController != null)
        {
            statsController.AddTempStatsModifier(modifier, time);
        }
        else
            Debug.Log($"{receiver.name} don't have \"CharacterStatsController\" component");
    }

    public CharacterStats GetModifier() { return modifier; }
}