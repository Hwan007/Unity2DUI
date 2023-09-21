using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsController : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;

    public CharacterStats CurrentStats { get; private set; }
    public LinkedList<CharacterStats> StatsModifiers = new LinkedList<CharacterStats>();
    private List<(LinkedListNode<CharacterStats>, float)> _tempStatsModifiers = new List<(LinkedListNode<CharacterStats>, float)>();

    private void Awake()
    {
        InitCharacterStats();
        //UpdateCharacterStats();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_tempStatsModifiers.Count > 0)
        {
            for (int i = 0; i < _tempStatsModifiers.Count; i++)
            {
                _tempStatsModifiers[i] = (_tempStatsModifiers[i].Item1, _tempStatsModifiers[i].Item2 - Time.deltaTime);
                if (_tempStatsModifiers[i].Item2 <= 0)
                {
                    StatsModifiers.Remove(_tempStatsModifiers[i].Item1);
                    _tempStatsModifiers.RemoveAt(i);
                    UpdateCharacterStats();
                }
            }
        }
    }

    private void InitCharacterStats()
    {
        CurrentStats = ScriptableObject.CreateInstance<CharacterStats>();
        UpdateStats((a, b) => b, baseStats);
    }

    private void UpdateCharacterStats()
    {
        foreach (CharacterStats modifier in StatsModifiers)
        {
            if (modifier.statChangeType == eStatChangeType.Add)
            {
                UpdateStats((x, y) => x + y, modifier);
            }
            else if (modifier.statChangeType == eStatChangeType.Multiple)
            {
                UpdateStats((x, y) => x * y, modifier);
            }
            else if (modifier.statChangeType == eStatChangeType.Override)
            {
                UpdateStats((x, y) => y, modifier);
            }
        }
    }

    private void UpdateStats(Func<float, float, float> operation, CharacterStats modifier)
    {
        CurrentStats.maxHealth = (int)operation(CurrentStats.maxHealth, modifier.maxHealth);

        CurrentStats.moveSpeed = operation(CurrentStats.moveSpeed, modifier.moveSpeed);
        CurrentStats.attackSpeed = operation(CurrentStats.attackSpeed, modifier.attackSpeed);

        CurrentStats.defense = (int)operation(CurrentStats.defense, modifier.defense);
        CurrentStats.avoidance = (int)operation(CurrentStats.avoidance, modifier.avoidance);

        CurrentStats.power = (int)operation(CurrentStats.power, modifier.power);

        // 정보가 추가되는 경우에 추가
    }

    public void AddStatModifier(CharacterStats modifier)
    {
        StatsModifiers.AddLast(modifier);
        UpdateCharacterStats();
    }

    public void RemoveStatModifier(CharacterStats modifier)
    {
        StatsModifiers.Remove(modifier);
        UpdateCharacterStats();
    }

    public void AddTempStatsModifier(CharacterStats modifier, float time)
    {
        var node = StatsModifiers.AddLast(modifier);
        if (time < StatModifyConsumeItemSO.TimeLimit)
            _tempStatsModifiers.Add((node, time));
    }
}
