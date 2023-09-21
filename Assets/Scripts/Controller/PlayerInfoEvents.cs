using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoEvents : MonoBehaviour
{
    public event Action OnNameChange;
    public event Action OnGoldChange;
    public event Action OnLevelChange;
    public event Action OnStatChange;

    public void CallGoldChange()
    {
        OnGoldChange?.Invoke();
    }

    public void CallLevelChange()
    {
        OnLevelChange?.Invoke();
    }

    public void CallStatsChange()
    {
        OnStatChange?.Invoke();
    }

    public void CallNameChange()
    {
        OnNameChange?.Invoke();
    }
}
