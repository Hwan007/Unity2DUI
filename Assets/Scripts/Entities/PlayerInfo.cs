using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerInfo", menuName = "Scriptable Object/PlayerInfo", order = -1)]
public class PlayerInfo : ScriptableObject
{
    public int Gold { get => _gold; private set => _gold = value; }
    public int Level { get => _level; private set => _level = value; }

    [SerializeField] private int _gold;
    [SerializeField] private int _level;
}
