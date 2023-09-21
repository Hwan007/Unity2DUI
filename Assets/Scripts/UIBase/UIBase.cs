using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected RectTransform _rectTransform;
    protected Canvas _canvas;
    

    protected bool _isTemp;

    protected virtual void Start()
    {
        
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
