using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileEnvironment : MonoBehaviour
{
    [SerializeField] private float _attackDamage = 3f;
    [SerializeField] private float _knockBackForce = 200f;

    [SerializeField] private bool _dieOnHit = true;
    [SerializeField] private GameObject _explodeyFX = null;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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

        if(_dieOnHit)
        {
            SpawnExplodey();

            Destroy(this.gameObject);
        }
    }

    private void SpawnExplodey()
    {
        var position = this.transform.position;
        var explodey = Instantiate(_explodeyFX);
        explodey.transform.position = position;
        GameplayAudioInit.vaseBreak.Play();
    }
}
