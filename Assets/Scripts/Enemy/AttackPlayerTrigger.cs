using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerTrigger : MonoBehaviour
{
    [SerializeField] private float _attackDamage = 3f;
    [SerializeField] private float _knockBackForce = 100f;

    private EnemyBase _enemyHost = null;

    private void Awake()
    {
        _enemyHost = this.GetComponentInParent<EnemyBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_enemyHost.IsDead())
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        var player = Player.Get();
        player.TakeDamage(_attackDamage);

        // Knock player back a bit.
        var playerRigidBody = player.GetRigidBody2d();
        playerRigidBody.velocity = Vector2.zero;

        var direction = player.GetPosition() - this.transform.position;
        direction.Normalize();
        if(direction.sqrMagnitude < 1f)
        {
            direction = new Vector3(0f, 1f, 0f);
        }

        playerRigidBody.AddForce(direction * _knockBackForce);
    }
}
