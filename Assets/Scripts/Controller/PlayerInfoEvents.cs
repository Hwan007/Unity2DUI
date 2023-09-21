using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoEvents : MonoBehaviour
{
    public event Action<string> OnNameChange;
    public event Action<int> OnGoldChange;
    public event Action<int> OnLevelChange;
    public event Action<CharacterStats> OnStatChange;

    public void CallGoldChange(int gold)
    {
        OnGoldChange?.Invoke(gold);
    }

    public void CallLevelChange(int changeLevel)
    {
        OnLevelChange?.Invoke(changeLevel);
    }

    public void CallStatsChange(CharacterStats stats)
    {
        OnStatChange?.Invoke(stats);
    }

    public void CallNameChange(string name)
    {
        OnNameChange?.Invoke(name);
    }
}
