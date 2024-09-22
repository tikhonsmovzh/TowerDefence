using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // он для всего что нужно сделать на старте, условно выключить включенные обьекты
    [SerializeField] private GameObject DeadPanel;
    [SerializeField] private GameObject EnemyControlSystem;
    void Start()
    {
        DeadPanel.SetActive(false);
    }

    public void Dead()
    {
        DeadPanel.SetActive(true);
        EnemyControlSystem.SetActive(false);
    }
}
