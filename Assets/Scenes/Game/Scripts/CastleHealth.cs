using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour // а эта залупа считает количество хп
{
    [SerializeField] private Slider Slider;
    [SerializeField] private TextMeshProUGUI[] Counters;
    private int _HP = 10, Gold = 0, Silver = 0;

    public void Damage()
    {
        _HP--;
        Slider.value = _HP;
        if (_HP == 0 )
            SceneManager.LoadScene(0);
    }

    public void ENemyIsDead()
    {
        Gold++;
        Silver += 20;
        Counters[0].text = Gold.ToString();
        Counters[1].text = Silver.ToString();
    }
}
