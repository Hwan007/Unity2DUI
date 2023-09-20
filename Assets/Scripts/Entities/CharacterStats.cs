using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStatChangeType
{
    Add,
    Multiple,
    Override,
}

[CreateAssetMenu(fileName = "DefaultStats", menuName = "Scriptable Object/Stats", order = 0)]
[Serializable]
public class CharacterStats : ScriptableObject
{
    public eStatChangeType statChangeType;
    [SerializeField][Range(0, 100)] public int maxHealth;
    
    [SerializeField][Range(0f, 10f)] public float moveSpeed;
    [SerializeField][Range(0f, 10f)] public float attackSpeed;
    
    [SerializeField][Range(0, 100)] public int defense;
    [SerializeField][Range(0, 100)] public int avoidance;
    
    [SerializeField][Range(0, 100)] public int power;
}
