using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGold : UIBase
{
    private PlayerInfoController _playerInfoController;
    private Action _callBack;
    [SerializeField] private TMP_Text _gold;

    public void Initialize(PlayerInfoController playerInfoController, Action callback = null)
    {
        _playerInfoController = playerInfoController;
        _callBack = callback;
        _gold.text = _playerInfoController.Info.Gold.ToString();
    }
    public override void CloseUI()
    {
        _callBack?.Invoke();
        base.CloseUI();
    }
    public override void Refresh()
    {
        base.Refresh();
        _gold.text = _playerInfoController.Info.Gold.ToString();
    }
}
