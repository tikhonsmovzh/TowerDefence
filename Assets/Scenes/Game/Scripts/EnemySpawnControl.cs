using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject _endCastle;
    [SerializeField] private TextMeshProUGUI _waveCounText;
    [SerializeField] private Slider _waveColdownSlider;
    [SerializeField] private float _waveColdownTime;
    [SerializeField] private Spawn[] _spawns;
    [SerializeField] private int _enemyCount;

    private int _waveCount = 0;

    private void Awake()
    {
        foreach (var spawn in _spawns)
            spawn.Points.Add(_endCastle);
    }

    private float _time = 0;
    private float _lastWaveTime = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time - _lastWaveTime > _waveColdownTime)
        {
            _lastWaveTime = _time;

            _waveColdownTime -= _waveCount % 2;

            foreach (var spawn in _spawns)
            {
                StartCoroutine(spawn.SpawnEnemy(_enemyCount + (_waveCount / 2)));
            }

            _waveCount++;

            _waveCounText.text = _waveCount.ToString();
        }

        _waveColdownSlider.value = 1f - (_time - _lastWaveTime) / _waveColdownTime;
    }
}