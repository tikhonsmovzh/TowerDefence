using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private EnemyConroller _enemy;
    public List<GameObject> Points;
    [SerializeField] private float _spawnTime;

    public IEnumerator SpawnEnemy(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            var Clone = Instantiate(_enemy, this.transform.position, Quaternion.identity);

            Clone.Points = Points;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
