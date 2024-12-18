using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public List<GameObject> Target { get; set; }
     
    public float Speed = 2f;                      // Set enemy speed
    private int _currentTargets = 0;              // Current target out of the list
    public CastleHpView CastleMony;               // I dont know wtf this is :(
    private Rigidbody2D _rbody; // Rigitbody component is used for detecting collisions

    [SerializeField] private float _range = 0.2f; // Enemy range for detecting targets
    [SerializeField] private Damaged _myState;    // Current state


    private void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    void Update() // Enemy brain loop
    {
        if (Target[_currentTargets].IsDestroyed()) // if the enemy reaches and destroys its target
            if (((Target[_currentTargets].transform.position - transform.position).sqrMagnitude < _range) //if the next target is in range
            && (_currentTargets < Target.Count - 1)) _currentTargets++; // then set target to the next available
        else  // if the target isnt reached yet continue moving
            _rbody.MovePosition(Vector3.MoveTowards(transform.position, Target[_currentTargets].transform.position, Speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (!collision.gameObject.CompareTag("Castle")) 
            return; // if the enemy colides with something else

        Damaged EnemyDamaged;         // ?

        if (EnemyDamaged = collision.gameObject.GetComponent<Damaged>()) // ??????
        {
            EnemyDamaged.HP--;        // ?
            Destroy(this.gameObject); // ?
        }
    }

    public void Hit() // Decrease enemy hp amount if the it is hit
    {
        _myState.HP--;
        if (_myState.HP < 1) CastleMony.SetSilver(1); // if the enemy dies then drop resources (silver)
    }

}