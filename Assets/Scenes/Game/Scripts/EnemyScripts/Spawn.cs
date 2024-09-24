using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;
    public List<GameObject> Points;
    [SerializeField] private float _spawnTime;

    public IEnumerator SpawnEnemy(int Num, int Speed, CastleHpView Mony)
    {
        for (int i = 0; i < Num; i++)
        {
            var Clone = Instantiate(_enemy, this.transform.position, Quaternion.identity);

            Clone.Points = Points;

            Clone._speed = Speed;

            Clone.Mony = Mony;

            _spawnTime = (float)(Speed / 3) - _spawnTime;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
