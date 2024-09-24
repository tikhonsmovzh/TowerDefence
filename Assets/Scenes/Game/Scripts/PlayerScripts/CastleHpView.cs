using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleHpView : MonoBehaviour
{
    [SerializeField] private Damaged[] _castleDamadges;
    [SerializeField] private Slider _helthBar;
    [SerializeField] private EventController Events;
    [SerializeField] private TextMeshProUGUI Gold;
    [SerializeField] private TextMeshProUGUI Silver;
    private float _castleHp, _silver, _gold;
    private static float _maxHp;

    private void Start()
    {
        _castleHp = 0;
        foreach (var i in _castleDamadges)
        {
            _castleHp += i.HP;
        }
        _maxHp = _castleHp;
        _silver = 0;
        _gold = 0;
    }

    void Update()
    {
        _helthBar.value = _castleHp / _maxHp;
        Gold.text = _gold.ToString();
        Silver.text = _silver.ToString();

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

    public void PlusGold(int Value)
    {
        _gold += Value;
    }

    public void PlusSilver(int Value)
    {
        _silver += Value;
    }
}
