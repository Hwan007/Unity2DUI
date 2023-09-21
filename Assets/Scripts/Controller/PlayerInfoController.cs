using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerInfoEvents
{
    private CharacterStatsController _characterStatsController;
    public PlayerInfo Info;

    private void Awake()
    {

    }

    private void Start()
    {
        _characterStatsController = GetComponent<CharacterStatsController>();
        OnNameChange += Info.SetName;
        OnLevelChange += Info.SetLevel;
        OnGoldChange += Info.SetGold;
    }

    public void RefreshInfo()
    {
        CallGoldChange(Info.Gold);
        CallNameChange(Info.Name);
        CallLevelChange(Info.Level);
    }
}
