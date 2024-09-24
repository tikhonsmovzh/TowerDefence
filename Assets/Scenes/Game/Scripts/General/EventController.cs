using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // �� ��� ����� ��� ����� ������� �� ������, ������� ��������� ���������� �������
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
