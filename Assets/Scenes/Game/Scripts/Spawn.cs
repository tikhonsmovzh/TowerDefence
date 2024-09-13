using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] MoveByEnemy Enemy;
    [SerializeField] GameObject[] Points;

    void Start()
    {
        StartCoroutine(SpawnEnemy(4));
    }
    public IEnumerator SpawnEnemy(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            var Clone = Instantiate(Enemy, this.transform.position, Quaternion.identity);
            Clone.Points = Points;
            yield return new WaitForSeconds(0.9f);
        }
    }
}
