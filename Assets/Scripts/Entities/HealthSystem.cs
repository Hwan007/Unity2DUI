using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private CharacterStatsController _characterStatsController;
    public int CurrentHealth { get; private set; }

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    [SerializeField] private AudioClip damageClip;

    private void Awake()
    {
        _characterStatsController = GetComponent<CharacterStatsController>();
    }

    private void Start()
    {
        CurrentHealth = _characterStatsController.CurrentStats.maxHealth;
    }

    public bool ChangeHealth(int point)
    {
        if (point == 0)
            return false;

        CurrentHealth += point;
        CurrentHealth = CurrentHealth > _characterStatsController.CurrentStats.maxHealth ? _characterStatsController.CurrentStats.maxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if (point > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();

            if (damageClip)
                SoundManager.PlayClip(damageClip);
        }

        if (CurrentHealth < 0)
        {
            CallDeath();
        }
        return true;
    }

    public void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
