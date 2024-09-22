using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTimer, _speed;
    [SerializeField] private string _treeTag;

    private CapsuleCollider2D _collider;

    private void Awake() => _collider = GetComponent<CapsuleCollider2D>();

    void Start() => Destroy(gameObject, _lifeTimer);

    void Update()
    {
        if (gameObject.IsDestroyed())
            return;

        transform.Translate(Vector2.left * Time.deltaTime * _speed);

        var result = new List<Collider2D>();

        if (Physics2D.OverlapCollider(_collider, new ContactFilter2D().NoFilter(), result) > 0)
        {
            var targets = result.Select(i => i.GetComponent<EnemyController>()).Where(i => i != null).ToArray();

            foreach (var target in targets)
                target.Hit();

            if (targets.Length > 0 || result.Where(i => i.tag == _treeTag).ToArray().Length > 0)
                Destroy(this.gameObject);
        }
    }
}
