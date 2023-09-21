using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public Image Image;
    public GameObject IsEquip;
    public TMP_Text Name;
    public TMP_Text Description;
    public TMP_Text Stats;

    private RectTransform _rectTransform;
    [HideInInspector] public BaseItemData _ItemData;
    private Action _callback;
    private Action<bool> _equipCallback;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {

    }

    public void InitInfo(BaseItemData item, bool isEquip, Action callback = null, Action<bool> equipCallback = null)
    {
        _ItemData = item;
        _callback = callback;
        _equipCallback = equipCallback;

        Name.text = item.GetName();
        Description.text = item.GetDescription();
        Image.sprite = item.GetImage();
        if (item is EquipItemSO)
        {
            var modifier = ((EquipItemSO)item).GetModifier();
            Stats.text = StatsToDescription(modifier);
        }
        else if (item is HealConsumeItemSO)
        {
            Stats.text = ((HealConsumeItemSO)item).GetHealPoint().ToString();
        }
        else if (item is StatModifyConsumeItemSO)
        {
            var modifier = ((StatModifyConsumeItemSO)item).GetModifier();
            Stats.text = StatsToDescription(modifier);
        }
        if (isEquip)
            IsEquip.SetActive(true);
        else
            IsEquip.SetActive(false);
    }

    public void EquipUI()
    {
        var ox = UIManager.Instance.ShowUI<UIOX>(eUIType.OX);
        ox.Initialize((x) => { GetResult(x); });
    }

    private void GetResult(bool isEquip)
    {
        _equipCallback?.Invoke(isEquip);
        if (isEquip)
            IsEquip.SetActive(true);
        else
            IsEquip.SetActive(false);
    }

    private string StatsToDescription(CharacterStats stats)
    {
        if (stats == null)
            return null;
        StringBuilder info = new StringBuilder();

        if (stats.power != 0) info.AppendLine($"공격력 : {stats.power}");
        if (stats.defense != 0) info.AppendLine($"방어력 : {stats.defense}");
        if (stats.avoidance != 0) info.AppendLine($"회피 : {stats.avoidance}");
        if (stats.maxHealth != 0) info.AppendLine($"체력 : {stats.maxHealth}");
        if (stats.moveSpeed <= 0) info.AppendLine($"이동속도 : {stats.moveSpeed.ToString("F1")}");
        if (stats.attackSpeed <= 0) info.AppendLine($"공격속도 : {stats.attackSpeed.ToString("F1")}");

        return info.ToString();
    }

    private void HideUI()
    {
        _callback?.Invoke();
        gameObject.SetActive(false);
    }
}
