using System;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    [SerializeField] private bool _canDie = true;

    public int MaxHP = 0;

    public Action<Damaged> OnDamage;
    public Action<Damaged> OnDeath;

    private int _currentHp;

    public int HP
    {
        get => _currentHp;

        set
        {   // Это полный пиздец я обязательно это перепишу но не сейчас
            _currentHp = Mathf.Min(MaxHP, value); 

            if (_currentHp <= 0 && _canDie) // if you died and are not in god mode
            {
                Destroy(gameObject);    // you die
                OnDeath?.Invoke(this);  // death message
            }

            OnDamage?.Invoke(this);
        }
    }

    private void Awake()
    {
        _currentHp = MaxHP;
    }
}
