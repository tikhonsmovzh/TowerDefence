using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public List<GameObject> Points { get; set; }
     
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _sens = 0.2f;
    [SerializeField] private Damaged _myState;

    private int _curentPoint = 0;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Points[_curentPoint].IsDestroyed() || (Points[_curentPoint].transform.position - transform.position).sqrMagnitude < _sens)
            _curentPoint += _curentPoint < Points.Count - 1 ? 1 : 0;

        if(!Points[_curentPoint].IsDestroyed())
            _body.MovePosition(Vector3.MoveTowards(transform.position, Points[_curentPoint].transform.position, _speed * Time.fixedDeltaTime));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Castle")
            return;

        Damaged damage;

        if (damage = collision.gameObject.GetComponent<Damaged>())
        {
            damage.HP--;
            Destroy(this.gameObject);
        }
    }
    public void Hit()
    {
        _myState.HP--;
    }

}
