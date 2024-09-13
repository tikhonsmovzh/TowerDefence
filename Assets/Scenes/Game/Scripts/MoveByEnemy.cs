using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveByEnemy : MonoBehaviour
{
    public GameObject[] Points = new GameObject[11];
    [SerializeField] float Speed = 2f;
    private int CurentPoint = 0;
    void Update()
    {
        if ((Points[CurentPoint].transform.position - transform.position).sqrMagnitude < 0.5f)
            CurentPoint += (CurentPoint <= Points.Length ? 1 : 0);
        transform.position = Vector3.MoveTowards(transform.position, Points[CurentPoint].transform.position, Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Castle")
        {Destroy(gameObject, 0);}
        Debug.Log(col.gameObject.name);
    }


}
