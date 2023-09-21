using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected RectTransform _rectTransform;
    protected Canvas _canvas;
    [SerializeField] protected TMP_Text _title;
    [SerializeField] protected TMP_Text _data;

    protected bool _isTemp;

    protected virtual void Start()
    {
        var texts = gameObject.GetComponentsInChildren<TMP_Text>();
    }
    public virtual void Refresh()
    {

    }

    public virtual void CloseUI()
    {
        UIManager.Instance.RemoveUIInList(this);
        gameObject.SetActive(false);
    }
}
