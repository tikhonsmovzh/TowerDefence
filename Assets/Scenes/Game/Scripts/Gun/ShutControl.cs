using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShutControl : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private float _shootSpeed, _shootRange, _scatter;
    [SerializeField] private GameObject _barrelObject, _bullet, _shootPoint;
    [SerializeField] private int _bulledAmount;

    [Header("EnemyScan")]
    [SerializeField] private string _enemyTag;
    [SerializeField] private float _rotStep;

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(0, 1, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.back, _shootRange);
    }

    private GameObject _targetEnemy;

    private void Awake() => StartCoroutine(ShootCuratine());

    private void FixedUpdate()
    {
        if (_targetEnemy == null || (_targetEnemy.transform.position - transform.position).magnitude > _shootRange)
        {
            _targetEnemy = GetTargetEnemy();

            if (_targetEnemy == null)
                return;
        }

        Vector2 minusVec = _targetEnemy.transform.position - transform.position;

        float target = Mathf.Atan2(minusVec.y, minusVec.x) / Mathf.PI * 180 + 180;

        float dif = target - _barrelObject.transform.localEulerAngles.z;

        while (Mathf.Abs(dif) > 180)
            dif -= 360 * Mathf.Sign(dif);

        if (Mathf.Abs(dif) <= _rotStep / 2)
            _barrelObject.transform.localRotation = Quaternion.Euler(0f, 0f, target);
        else
            _barrelObject.transform.localRotation = Quaternion.Euler(0f, 0f, _barrelObject.transform.localEulerAngles.z + Mathf.Sign(dif) * _rotStep);
    }

    private GameObject GetTargetEnemy()
    {
        var enemyes = Physics2D.OverlapCircleAll(transform.position, _shootRange)
            .Where(col => col.tag == _enemyTag && col.GetComponent<EnemyController>())
            .Select(col => col.gameObject).ToArray();

        if (enemyes.Length == 0)
            return null;
        else
            return enemyes[0];
    }

    private IEnumerator ShootCuratine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootSpeed);

            if (_targetEnemy != null)
            {
                for (var i = 0; i < _bulledAmount; i++)
                {
                    Instantiate(_bullet, _shootPoint.transform.position, Quaternion.Euler(_barrelObject.transform.localEulerAngles.x,
                        _barrelObject.transform.localEulerAngles.y, _barrelObject.transform.localEulerAngles.z + Random.Range(-_scatter, _scatter)));
                }
            }
        }
    }
}
