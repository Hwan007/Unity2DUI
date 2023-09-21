using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIBase
{
    private CharacterStatsController _statsController;
    private CharacterStats _stats;
    private HealthSystem _health;
    private Action _callBack;
    private UITextInfo _textInfo;

    protected override void Start()
    {
        base.Start();
    }
    public void Initialize(HealthSystem health, CharacterStatsController statsController, Action callBack = null)
    {
        _statsController = statsController;
        _stats = statsController.CurrentStats;
        _callBack = callBack;
        _health = health;
        _textInfo = GetComponent<UITextInfo>();
        _textInfo.ExitBtn.gameObject.SetActive(true);
        _textInfo.Title.text = "�������ͽ�";
        _textInfo.Size.anchoredPosition = new Vector2() { x = 550, y = -10 };
        _textInfo.Size.sizeDelta = new Vector2() { x = -1300, y = -500 };
        _textInfo.ExitBtn.onClick.AddListener(CloseUI);
        _textInfo.Data.text = StatsToDescription();
    }

    public override void Refresh()
    {
        _textInfo.Data.text = StatsToDescription();
        base.Refresh();
    }

    public override void CloseUI()
    {
        _callBack?.Invoke();
        base.CloseUI();
    }

    private string StatsToDescription()
    {
        if (_stats == null)
            return null;
        StringBuilder info = new StringBuilder();

        info.AppendLine($"���ݷ� : {_stats.power}");
        info.AppendLine($"���� : {_stats.defense}");
        info.AppendLine($"ȸ�� : {_stats.avoidance}");
        info.AppendLine($"ü�� : {_health.CurrentHealth}/{_stats.maxHealth}");
        info.AppendLine($"�̵��ӵ� : {_stats.moveSpeed.ToString("F1")}");
        info.AppendLine($"���ݼӵ� : {_stats.attackSpeed.ToString("F1")}");

        return info.ToString();
    }
}
