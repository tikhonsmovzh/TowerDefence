using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControlSystem : MonoBehaviour
{
    [SerializeField] private Spawn[] Spawn;
    [SerializeField] private Slider Slider;
    [SerializeField] private TextMeshProUGUI Text;
    private float _etalonTime = 60.0f;
    private float _time = 60.0f;
    private int _enemyCol = 4, _colVoln = 0;
    void Start()
    {
        Slider.maxValue = _time;
    }

    void Update()
    {
        Slider.value = _time;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            _time -= Time.deltaTime;
        if (_time <= 0)
        {
            for (int i = 0; i < Spawn.Length; i++)
                StartCoroutine(Spawn[i].SpawnEnemy(_enemyCol));
            _time = (_colVoln % 2 == 0 ? _etalonTime - 1.0f : _etalonTime);
            _etalonTime = _time;
            _colVoln++;
            _enemyCol++;
           Slider.maxValue = _time;
            Text.text = _colVoln.ToString();
        }
    }
}
