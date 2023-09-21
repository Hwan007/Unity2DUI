using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerInfoEvents
{
    private CharacterStatsController _characterStatsController;
    [SerializeField] private PlayerInfo _playerInfo;

    private void Awake()
    {
        _characterStatsController = GetComponent<CharacterStatsController>();
    }


}
