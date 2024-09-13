using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private int _HP;

    public void Damage()
    {
        _HP--;
        _slider.value = _HP;
    }
}
