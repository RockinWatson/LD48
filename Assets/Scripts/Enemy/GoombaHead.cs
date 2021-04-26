using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHead : MonoBehaviour
{
    private Collider2D _collider2D = null;

    private void Awake()
    {
        _collider2D = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillHost();

            var player = Player.Get();
            player.GetCharacterController2D().ResetDoubleJump();
            var playerRigidBody = player.GetRigidBody2d();
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(new Vector2(0f, 150f));
        }
    }

    private void KillHost()
    {
        var host = this.GetComponentInParent<EnemyBase>();
        host.Kill();
        GameplayAudioInit.playerDamage1.Play();
    }
}
