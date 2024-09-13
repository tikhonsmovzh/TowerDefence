using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesDamage : MonoBehaviour
{
    [SerializeField] CastleHealth MainCastle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MainCastle.Damage();
    }
}
