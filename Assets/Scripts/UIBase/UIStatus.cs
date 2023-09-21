using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UIStatus : UIBase
{
    private CharacterStatsController _statsController;
    private CharacterStats _stats;
    private HealthSystem _health;
    private Action _callBack;

    protected override void Start()
    {
        base.Start();
    }
    public void Initialize(HealthSystem health, CharacterStatsController statsController, Action callBack)
    {
        _statsController = statsController;
        _stats = statsController.CurrentStats;
        _callBack = callBack;

        _data.text = StatsToDescription();
    }

    public override void Refresh()
    {
        _data.text = StatsToDescription();
        base.Refresh();
    }

    public override void CloseUI()
    {
        _callBack();
        base.CloseUI();
    }

    private string StatsToDescription()
    {
        if (_stats == null)
            return null;
        StringBuilder info = new StringBuilder();

        info.AppendLine($"공 격 력 : {_stats.power}");
        info.AppendLine($"방 어 력 : {_stats.defense}");
        info.AppendLine($"회    피 : {_stats.avoidance}");
        info.AppendLine($"체    력 : {_health.CurrentHealth}/{_stats.maxHealth}");
        info.AppendLine($"이동속도 : {_stats.moveSpeed.ToString("F1")}");
        info.AppendLine($"공격속도 : {_stats.attackSpeed.ToString("F1")}");

        return info.ToString();
    }
}
