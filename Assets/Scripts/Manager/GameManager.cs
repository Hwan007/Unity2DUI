using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] public GameObject Player;
    public int SellPercentage { get; }
    [SerializeField][Range(1,100)] private int _sellPercentage;

    private void Awake()
    {
        Instance = this;
    }
}
