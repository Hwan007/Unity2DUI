using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : PlayerInfoEvents
{
    private CharacterStatsController _characterStatsController;
    public PlayerInfo Info;

    private void Awake()
    {

    }

    private void Start()
    {
        _characterStatsController = GetComponent<CharacterStatsController>();
    }

    public void RefreshInfo()
    {
        CallGoldChange();
        CallNameChange();
        CallLevelChange();
    }
}
