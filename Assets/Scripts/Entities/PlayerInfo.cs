using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerInfo", menuName = "Scriptable Object/PlayerInfo", order = -1)]
public class PlayerInfo : ScriptableObject
{
    public string Name { get => _name; private set => _name = value; }
    public int Gold { get => _gold; private set => _gold = value; }
    public int Level { get => _level; private set => _level = value; }

    [SerializeField] private int _gold;
    [SerializeField] private int _level;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;

    public void SetName(string name) { _name = name; }
    public void SetGold(int gold) { _gold = gold; }
    public void SetLevel(int level) { _level = level; }

}
