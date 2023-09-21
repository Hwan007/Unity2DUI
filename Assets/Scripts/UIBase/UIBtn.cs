using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBtn : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private CharacterStatsController _characterController;
    private HealthSystem _healthSystem;
    private bool isOpenStatus = false;

    private void Start()
    {
        _characterController = _player.GetComponent<CharacterStatsController>();
        _healthSystem = _player.GetComponent<HealthSystem>();
    }
    public void OpenStatus()
    {
        if (!isOpenStatus)
        {
            var window = UIManager.Instance.ShowUI<UIStatus>(eUIType.Status);
            window.Initialize(_healthSystem, _characterController, () => { isOpenStatus = false; });
        }
    }

    public void OpenInventory()
    {

    }

    public void OpenStore()
    {

    }
}
