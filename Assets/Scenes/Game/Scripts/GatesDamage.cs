using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesDamage : MonoBehaviour // эта залупа читает касания с противниками
{
    [SerializeField] CastleHealth MainCastle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MainCastle.Damage();
    }
}
