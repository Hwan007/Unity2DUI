using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TMPro;
using UnityEngine;

public class UINameLevel : UIBase
{
    private PlayerInfoController _playerInfoController;
    private Action _callBack;
    private UITextInfo _textInfo;
    public void Initialize(PlayerInfoController playerInfoController, Action callback = null)
    {
        _playerInfoController = playerInfoController;
        _callBack = callback;
        _textInfo = GetComponent<UITextInfo>();
        _textInfo.ExitBtn.gameObject.SetActive(false);
        _textInfo.Title.text = "Ä³¸¯ÅÍ";
        _textInfo.Size.anchoredPosition = new Vector2() { x = -650, y = -30 };
        _textInfo.Size.sizeDelta = new Vector2() { x = -1500, y = -700 };
    }
    public override void CloseUI()
    {
        _callBack?.Invoke();
        base.CloseUI();
    }
    public override void Refresh()
    {
        base.Refresh();
        if (_textInfo.Data != null)
            _textInfo.Data.text = InfoToString();
    }

    private string InfoToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_playerInfoController.Info.Name);
        sb.AppendLine("Lv. " + _playerInfoController.Info.Level.ToString());
        return sb.ToString();
    }
}
