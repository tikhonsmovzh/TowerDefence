using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleHpView : MonoBehaviour
{
    [SerializeField] private Damaged[] _castleDamadges;
    [SerializeField] private Slider _helthBar;
    [SerializeField] private EventController Events;
    private float _castleHp;
    private static float _maxHp;

    private void Start()
    {
        _castleHp = 0;
        foreach (var i in _castleDamadges)
        {
            _castleHp += i.HP;
        }
        _maxHp = _castleHp;
    }

    void Update()
    {
        _helthBar.value = _castleHp / _maxHp;

        _castleHp = 0;

        foreach (var i in _castleDamadges)
        {
            _castleHp += i.HP;
        }

        if (_castleDamadges[0].HP <= 0)
        {
            Events.Dead();
            _helthBar.value = 0;
        }
    }
}
