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

            var player = Player.Get().GetRigidBody2d();
            player.velocity = Vector2.zero;
            player.AddForce(new Vector2(0f, 150f));
        }
    }

    private void KillHost()
    {
        var host = this.GetComponentInParent<EnemyBase>();
        host.Kill();
    }
}
