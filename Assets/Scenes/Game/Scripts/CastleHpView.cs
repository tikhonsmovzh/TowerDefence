using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleHpView : MonoBehaviour
{
    [SerializeField] private Damaged[] _castleDamadges;
    [SerializeField] private Slider _helthBar;

    void Update()
    {
        float sumMaxHp = 0;
        float sumHP = 0;

        foreach(var i in _castleDamadges)
        {
            sumHP += (float)i.HP;
            sumMaxHp += (float)i.MaxHP;
        }

        _helthBar.value = sumHP / sumMaxHp;
    }
}
