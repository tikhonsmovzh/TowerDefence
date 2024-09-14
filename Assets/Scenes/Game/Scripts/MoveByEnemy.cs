using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByEnemy : MonoBehaviour
{
    public GameObject[] Points { get; set; }

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _sens = 0.2f;

    private int _curentPoint = 0;
    public int _HP = 10;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Points[_curentPoint].transform.position - transform.position).sqrMagnitude < _sens)
            _curentPoint += _curentPoint <= Points.Length ? 1 : 0;

        if (_HP <= 0)
        {
            var GO = GameObject.FindGameObjectWithTag("MainCastle");
            GO.GetComponent<CastleHealth>().ENemyIsDead();
            Destroy(gameObject, 0);
        }

        _body.MovePosition(Vector3.MoveTowards(transform.position, Points[_curentPoint].transform.position, _speed * Time.fixedDeltaTime));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Castle")
            Destroy(gameObject, 0);
        if (collision.gameObject.tag == "Bullet")
            _HP--;
    }
}
