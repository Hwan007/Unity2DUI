using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEquipment", menuName = "Scriptable Object/Item/Equipment", order = 2)]
public class EquipItemSO : BaseItemData, IEquipable
{
    [SerializeField] private CharacterStats statModifier;
    private CharacterStatsController equipCharacter;
    [SerializeField] private eEquipPart equipType;

    public eEquipPart GetEquipPart()
    {
        return equipType;
    }
    public override int GetID()
    {
        if (ID == -1)
            ID = ItemDataManager.Instance.GetID(this);
        return ID;
    }
    public virtual void OnEquip(CharacterStatsController character)
    {
        character.AddStatModifier(statModifier);
        equipCharacter = character;
    }
    public virtual void OnUnEquip(CharacterStatsController character)
    {
        character.RemoveStatModifier(statModifier);
        equipCharacter = null;
    }
    public CharacterStats GetModifier()
    {
        return statModifier;
    }
}
