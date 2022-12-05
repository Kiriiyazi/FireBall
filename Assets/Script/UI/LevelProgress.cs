using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerBuilder _builder;

    private float _towerStartSize;

    private void Awake()
    {
        _towerStartSize = _builder.GetTowerStartSize();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _tower.SizeUpdated += OnTowerSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnTowerSizeUpdated;
    }

    private void OnTowerSizeUpdated(int size)
    {
        if (size != _towerStartSize)
        {
            _slider.value = (_towerStartSize - size) / _towerStartSize;
        }
    }

}
