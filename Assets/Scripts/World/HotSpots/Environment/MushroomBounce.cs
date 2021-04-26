using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 1000f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ApplyBounceForceToPlayer();
        }
    }

    private void ApplyBounceForceToPlayer()
    {
        var player = Player.Get().GetRigidBody2d();

        player.AddForce(new Vector2(0f, _bounceForce));
    }
}
