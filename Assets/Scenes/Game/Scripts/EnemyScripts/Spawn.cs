using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;
    public List<GameObject> eTarget;
    [SerializeField] private float _spawnCooldown;

    public IEnumerator Spawn(int Amount, int eSpeed, CastleHpView CurrentMony)
    {
        for (int i = 0; i < Amount; i++)
        {
            var Clone = Instantiate(_enemy, this.transform.position, Quaternion.identity);

            Clone.Target = eTarget;
            Clone.Speed = eSpeed;
            Clone.CastleMony = CurrentMony;

            _spawnCooldown = (float)(eSpeed / 3) - _spawnCooldown;

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
