using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private MoveByEnemy _enemy;
    [SerializeField] private GameObject[] _points;
    [SerializeField] private float _spawnTime;

    void Start()
    {
        StartCoroutine(SpawnEnemy(4));
    }
    public IEnumerator SpawnEnemy(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            var Clone = Instantiate(_enemy, this.transform.position, Quaternion.identity);

            Clone.Points = _points;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
