using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweemShoot;
    [SerializeField] private float _recoilDistance;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private AudioSource _shootAudio;
    [SerializeField] private int _maxRage;
    [SerializeField] private float _timeDelay;
    [SerializeField]private float _currentRage;
    private float _currentTimeDelay;


    private float _timeAfterShoot;

    private void Start()
    {
        _currentTimeDelay = _timeDelay;
    }

    private void Update()
    {
        Debug.Log(_currentRage);
        _timeAfterShoot += Time.deltaTime;

        if (_currentRage <= _maxRage)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_timeAfterShoot > _delayBetweemShoot)
                {
                    _shootAudio.pitch = Random.Range(1,1.2f);
                    _shootAudio.Play();
                    Shoot();
                    AnimationTankShoot();
                    _currentRage += 10;
                }
            }
            if (_currentRage >= 0)
                _currentRage -= 0.1f;    
        }
        else if( _currentRage > _maxRage)
        {
            
            _timeDelay -= Time.deltaTime;
            if (_timeDelay <= 0)
            {
                _timeDelay = _currentTimeDelay;
                _currentRage = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }

    private void AnimationTankShoot()
    {
        transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweemShoot / 2).SetLoops(2, LoopType.Yoyo);
        _timeAfterShoot = 0;
        _shootEffect.Play();
    }
}
