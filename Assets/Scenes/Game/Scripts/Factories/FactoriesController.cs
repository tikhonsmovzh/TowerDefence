using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoriesController : MonoBehaviour
{
    [SerializeField] private float TimeForCreat;
    [SerializeField] private int Overheat;
    [SerializeField] private int Efficiency;
    [SerializeField] private SpriteRenderer OverHeatEdent;
    private int _overheatNow = 0;
    private float _nowTime = 0.0f;
    private bool _hot = false;
    private CastleHpView Mony;
    private void Start()
    {
        Mony = GameObject.FindWithTag("MainCastle").GetComponent<CastleHpView>();
    }
    void Update()
    {
        _nowTime = (_nowTime <= 0 ? TimeForCreat : _nowTime);
        _nowTime -= Time.deltaTime;
        if (_nowTime <= 0)
        {
            Mony.SetGold(Efficiency);
            _overheatNow++;
            if (_hot)
                _hot = false;
        }
        if (_overheatNow == Overheat)
        {
            _nowTime = TimeForCreat * 5;
            _hot = true;
            _overheatNow = 0;
        }
        if (_hot)
        {
            OverHeatEdent.color = new Color(1, 0, 0, 0.5f);
        }
        else
        {
            OverHeatEdent.color = new Color(1, 0, 0, 0);
        }
    }
}
