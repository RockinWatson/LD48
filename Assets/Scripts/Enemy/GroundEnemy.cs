using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : EnemyBase
{
    private Rigidbody2D _rigidBody2D = null;

    private void Awake()
    {
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
    }
}
