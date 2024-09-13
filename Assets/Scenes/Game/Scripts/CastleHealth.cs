using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private int _HP = 10;

    public void Damage()
    {
        _HP--;
        _slider.value = _HP;
        if (_HP == 0 )
            SceneManager.LoadScene(0);
    }
}
