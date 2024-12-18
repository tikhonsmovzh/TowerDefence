using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject _castleTarget;  
    [SerializeField] private TextMeshProUGUI _wAmountText;  // Wave number (text UI)
    [SerializeField] private Slider _wCooldownSld;          // Slider for wave cooldown
    [SerializeField] private float _wCooldownTime;          // Cooldown until next wave
    [SerializeField] private EnemySpawner[] _placedSpawners;// Initializing our spawners
    [SerializeField] private int _eAmount;                  // Amount of enemies
    [SerializeField] private CastleHpView EscMony;          // ?

    private int _wAmount = 0;        // Current wave number
    private float _currentTime = 0;  // Current elapsed time
    private float _lastWaveTime = 0; // Time passed from previous wave (this/last)

    private int _currentSpeed;       // Set speed for spawned enemies
    private int _spawnAmount;        // Set amount of spawned enemies

    private void Awake()
    {
        foreach (var NewEnemy in _placedSpawners)
            NewEnemy.eTarget.Add(_castleTarget);
    }   // Setting every new spawned enemy a target for destroing (our castle)

    private void Update()
    {
        _currentTime += Time.deltaTime; // Increase elapsed time

        if(_currentTime - _lastWaveTime > _wCooldownTime) // if the next wave cooldown ended
        {
            _lastWaveTime = _currentTime; // Reset cooldown
            if (_wCooldownTime > 3.0f) _wCooldownTime -= _wAmount % 2;

            _spawnAmount = _eAmount + (_wAmount / 2);
            _currentSpeed = _wAmount / 3;
            if(_currentSpeed > 3) _currentSpeed = 3; // Set a limit for the max enemy speed

            foreach (var EnemySpawner in _placedSpawners) // Spawn the enemies
                StartCoroutine(EnemySpawner.Spawn(_spawnAmount, _currentSpeed, EscMony));

            _wAmount++;                           // Increase the nex wave number
            _wAmountText.text = _wAmount.ToString(); // Write the new wave number
        }

        // Update the slider with relevant cooldown until next wave
        _wCooldownSld.value = 1f - (_currentTime - _lastWaveTime) / _wCooldownTime;
    }
}