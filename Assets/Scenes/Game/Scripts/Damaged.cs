using System;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    [SerializeField] private bool _iMustDead = true;

    public int MaxHP = 0;

    public Action<Damaged> OnDamadge;
    public Action<Damaged> OnDeath;

    private int _currentHp;

    public int HP
    {
        get => _currentHp;

        set
        {
            _currentHp = Mathf.Min(MaxHP, value);

            if (_currentHp <= 0 && _iMustDead)
            {
                Destroy(gameObject);
                OnDeath?.Invoke(this);
            }

            OnDamadge?.Invoke(this);
        }
    }

    private void Awake()
    {
        _currentHp = MaxHP;
    }
}
